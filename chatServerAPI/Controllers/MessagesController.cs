using Domain;
using Domain.apiDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using Repository;
using Services;
using Services.messages;
using Services.users;

namespace chatServerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/contacts/{friendId}/messages/")]
    public class MessagesController : ControllerBase
    {
        private IServiceMessages _service;
        private IServiceUsers _usersService;
        private string _myId;

        public MessagesController(UsersContext usersContext)
        {
            _service = new ServiceMessages(usersContext);
            _usersService = new ServiceUsers(usersContext);
        }

        private void SetMyId()
        {
            string? loggedUser = HttpContext.User.FindFirst("username")?.Value;
            if (loggedUser != null)
            {
                _myId = loggedUser;
            }
        }

        //[get a specific content in conversation with friend ]
        //api/contacts/alice/messages/181
        [HttpGet("{messageId}/")]
        public async Task<ActionResult<ContentApi>> GetConversation(string friendId, int messageId)
        {
            SetMyId();
            if (_service.GetConversation(_myId, friendId) == null)
            {
                return NotFound("not found contact with that id");
            }


            ContentApi? content = _service.Get(_myId, friendId, messageId);
            if (content == null)
            {
                return NotFound("not content found with the id");
            }

            return Ok(content);
        }

        //[get all conversation with the friend]
        //api/contacts/alice/messages/
        [HttpGet]
        public async Task<ActionResult<List<ContentApi>>> GetConversation(string friendId)
        {
            SetMyId();
            List<ContentApi>? listCon = _service.GetConversation(_myId, friendId);
            if (listCon == null)
            {
                return NotFound();
            }
            return Ok(listCon);
        }

        // DELETE: api/Contacts/alice/messages/181
        [HttpDelete("{idMessages}/")]
        public async Task<IActionResult> DeleteContact(string friendId, int idMessages)
        {
            SetMyId();
            if (_service.GetConversation(_myId, friendId) == null)
            {
                return NotFound();
            }

            ContentApi? contentApi = _service.Get(_myId, friendId, idMessages);
            if (contentApi == null)
            {
                return NotFound();
            }

            _service.Delete(_myId, friendId, contentApi);
            return NoContent();
        }

        // POST
        // api/contacts/alice/messages
        [HttpPost]
        public async Task<ActionResult<Contact>> PostMessages(string friendId, [FromBody] ContentApi content)
        {
            SetMyId();
            List<ContentApi>? conversation = _service.GetConversation(_myId, friendId);
            if (conversation == null)
            {
                return NotFound();
            }

            int? nextId = 0;
            if (conversation.Count ==0 )
            {
                 nextId = 1;
            }
            else
            {
                nextId = conversation.Max(x => x.Id) + 1;
            }
            DateTime date = DateTime.Now;
            string dateJS = date.ToString("o");
            
            ContentApi contentApi = new ContentApi()
                {Content = content.Content, Created = dateJS, Id = nextId, Sent = true};
            _service.AddContent(_myId, friendId, contentApi);
            _usersService.UpdateLastMessage(_myId,friendId,content.Content,dateJS);

            return NoContent();
        }

        //[PUT]
        //api/contacts/alice/messages/183
        [HttpPut("{idMessages}/")]
        public async Task<IActionResult> PutMessage(string friendId, int idMessages,[FromBody] ContentApi contentInput)
        {
            string content = contentInput.Content;
            SetMyId();
            ContentApi? contentApi = _service.Get(_myId, friendId, idMessages);
            if (contentApi != null)
            {
                contentApi.Content = content;
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}