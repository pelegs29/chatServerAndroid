using Domain;
using Domain.apiDomain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Services.messages;

public class ServiceMessages : IServiceMessages
{
    public void AddContent(string myId, string idFriend, ContentApi contentApi)
        //TODO : check
    {
        using (var db = new ChatDbContext())
        {
            Conversation? conversation = db.Conversations
                .Include(x => x.Contents).FirstOrDefault(x => x.from == myId && x.to == idFriend);
            if (conversation != null)
            {
                conversation.Contents?.Add(contentApi);
                db.Update(conversation);
                db.SaveChanges();
            }
        }
        // GetConversation(myId, idFriend).Add(contentApi);
    }

    //TODO : check
    public void AddConv(Conversation conv)
    {
        using (var db = new ChatDbContext())
        {
            db.Add(conv);
            db.SaveChanges();
        }
        // _conversations?.Add(conv);
    }

    public IEnumerable<Conversation> GetAll()
    {
        throw new NotImplementedException();
    }

    public int GetLastConvId()
    {
        using (var db = new ChatDbContext())
        {
            return db.Conversations.ToList().Count;
        }
    }

    public List<ContentApi>? GetConversation(string myId, string idFriend)
    {
        using (var db = new ChatDbContext())
        {
            Conversation? conversations = db.Conversations.Include(x => x.Contents)
                .FirstOrDefault(conv => conv.from == myId && conv.to == idFriend);
            if (conversations != null)
            {
                if (conversations.Contents != null)
                {
                    return conversations.Contents;
                }

                return null;
            }

            return null;
        }
    }

    public ContentApi? Get(string myId, string idUserFriend, int idMessage)
    {
        List<ContentApi>? conv = GetConversation(myId, idUserFriend);
        if (conv == null)
        {
            return null;
        }

        ContentApi? content = conv.FirstOrDefault(x => x.Id == idMessage);
        return content;
    }

    public void Update(string idFriend, string content)
    {
        throw new NotImplementedException();
    }

    public void Delete(string myId, string idFriend, ContentApi contentApi)
    {
        GetConversation(myId, idFriend).Remove(contentApi);
    }
}