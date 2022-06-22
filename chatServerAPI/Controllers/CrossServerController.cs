using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chatServerAPI.Hubs;
using Domain;
using Domain.apiDomain;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Repository;
using Services;
using Services.messages;
using Services.users;

namespace chatServerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class CrossServerController : ControllerBase
    {
        private IServiceMessages _messagesService;
        private IServiceUsers _usersService;
        private readonly IHubContext<ChatHub> _hubContext;
        private static Mutex _mutex = new Mutex();

        public CrossServerController(IHubContext<ChatHub> hub)
        {
            _messagesService = new ServiceMessages();
            _usersService = new ServiceUsers();
            _hubContext = hub;

            _mutex.WaitOne();
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("private_key.json")
                });
            }

            _mutex.ReleaseMutex();
        }

        // v v v v v v v v v SignalR v v v v v v v v v 

        private async Task SignalRSendMessage(string fromUser, string toUser, string message, string time)
        {
            string connectionId;
            if (ChatHub.ConnectionsDict.ContainsKey(toUser))
            {
                connectionId = ChatHub.ConnectionsDict[toUser];
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveMessage", fromUser, message, time);
            }
        }


        private async Task SignalRAddUser(string fromUser, string toUser, string server)
        {
            string connectionId;
            if (ChatHub.ConnectionsDict.ContainsKey(toUser))
            {
                connectionId = ChatHub.ConnectionsDict[toUser];
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveContact", fromUser, server);
            }
        }

        // ^ ^ ^ ^ ^ ^ ^ ^ ^ SignalR ^ ^ ^ ^ ^ ^ ^ ^ ^ 


        // v v v v v v v v v FireBase v v v v v v v v v

        [HttpPost("firebase/register/")]
        public async Task RegisterFirebase([FromBody] FirebaseUserApi user)
        {
            if (FireBaseHub.ConnectionsDict.ContainsKey(user.username))
            {
                FireBaseHub.ConnectionsDict.Remove(user.username);
            }

            FireBaseHub.ConnectionsDict.Add(user.username, user.token);
        }

        private void FirebaseSendNotification(string fromUser, string toUser, string message, string time)
        {
            if (FireBaseHub.ConnectionsDict.ContainsKey(toUser))
            {
                var notification = new Message()
                {
                    Data = new Dictionary<string, string>()
                    {
                        {"type", "0"}, {"fromUser", fromUser}, {"time", time}
                    },
                    Token = FireBaseHub.ConnectionsDict[toUser],
                    Notification = new Notification()
                    {
                        Title = "You've received a message from " + fromUser,
                        Body = message
                    }
                };

                string response = FirebaseMessaging.DefaultInstance.SendAsync(notification).Result;
            }
        }


        private void FirebaseAddContact(string fromUser, string toUser, string server)
        {
            if (FireBaseHub.ConnectionsDict.ContainsKey(toUser))
            {
                var notification = new Message()
                {
                    Data = new Dictionary<string, string>()
                    {
                        {"type", "1"}, {"fromUser", fromUser}, {"server", server}
                    },
                    Token = FireBaseHub.ConnectionsDict[toUser],
                    Notification = new Notification()
                    {
                        Title = fromUser + " added you as a contact",
                        Body = "chat with " + fromUser + " now !"
                    }
                };

                string response = FirebaseMessaging.DefaultInstance.SendAsync(notification).Result;
            }
        }


        // ^ ^ ^ ^ ^ ^ ^ ^ ^ FireBase ^ ^ ^ ^ ^ ^ ^ ^ ^ 


        /**
         * getting TransferApi object contains: from, to, content.
         * this query will arrive from the sender server,
         * so myID is transfer.to and the friend id is the transfer.from.
         */
        [HttpPost("transfer/")]
        public async Task<IActionResult> Transfer([FromBody] TransferApi transfer)
        {
            if (transfer.from == null || transfer.to == null)
            {
                return BadRequest();
            }

            // myId == transfer.to
            string fromId = transfer.from;
            string date = DateTime.Now.ToString("o");

            List<ContentApi>? listCon = _messagesService.GetConversation(transfer.to, fromId);
            ContentApi cont = new ContentApi() {Content = transfer.content, Created = date, Sent = false};
            if (listCon == null)
            {
                Conversation newConv = new Conversation()
                    {Contents = new List<ContentApi> {cont}, from = fromId, to = transfer.to};
                _messagesService.AddConv(newConv);
            }
            else
            {
                // if (listCon.Count == 0)
                // {
                //     cont.Id = 1;
                // }
                // else
                // {
                //     cont.Id = listCon.Last().Id + 1;
                // }
                _messagesService.AddContent(transfer.to, fromId, cont);
            }

            //update the last message in the contact list of the user
            _usersService.UpdateLastMessage(transfer.to, transfer.from, transfer.content, date);

            await SignalRSendMessage(transfer.from, transfer.to, transfer.content, date);

            FirebaseSendNotification(transfer.from, transfer.to, transfer.content, date);

            return Ok();
        }

        /**
         * getting InvitationApi object contains: from, to, content.
         * this query will arrive from the sender server,
         * hence myID is invitation.to and the friendID is invitation.from. 
         */
        [HttpPost("invitations/")]
        public async Task<IActionResult> Invitation([FromBody] InvitationApi invitation)
        {
            string nickname;
            if (invitation.name != null)
            {
                nickname = invitation.name;
            }
            else
            {
                nickname = invitation.from;
            }

            //check if the user exists in the userslist
            if (_usersService.Get(invitation.from) == null)
            {
                _usersService.Add(new User()
                {
                    Id = invitation.from, Name = nickname,
                    Password = null, Contacts = new List<ContactApi>()
                });
            }

            string contactId = invitation.from;
            string myId = invitation.to;

            ContactApi contact = new ContactApi()
            {
                Id = invitation.from, last = null, lastdate = null, Name = nickname,
                Server = invitation.server, contactOf = myId
            };

            await SignalRAddUser(invitation.from, invitation.to, invitation.server);

            FirebaseAddContact(invitation.from, invitation.to, invitation.server);

            _usersService.AddContact(contact);

            Conversation conv = new Conversation()
            {
                Contents = new List<ContentApi>(), from = myId,
                to = contactId
            };
            _messagesService.AddConv(conv);

            return Ok();
        }
    }
}