using Domain;
using Domain.apiDomain;
using Repository;

namespace Services.users;

public class ServiceUsers : IServiceUsers
{
    public void Add(User user)
    {
        // _users.usersList.Add(user);
        using (var db = new ChatDbContext())
        {
            User? userFound = Get(user.Id);
            if (userFound == null)
            {
                db.Add(user);
                db.SaveChanges();
            }
        }
    }

    //add contact to the contact list of the user with the id
    public void AddContact(ContactApi contact)
    {
        // Get(id).Contacts.Add(contact);
        using (var db = new ChatDbContext())
        {
            User? user = Get(contact.contactOf);
            ContactApi? friend = user.Contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (friend == null)
            {
                db.Remove(user);
                db.SaveChanges();
                user.Contacts.Add(contact);
                db.Add(user);
                db.SaveChanges();
            }
        }
    }

    public IEnumerable<User>? GetAll()
    {
        //return _users.usersList;
        using (var db = new ChatDbContext())
        {
            var items = db.Users.ToList();
            return items;
        }
    }


    public User? Get(string id)
    {
        // return _users.usersList.FirstOrDefault(x => x.Id == id);
        using (var db = new ChatDbContext())
        {
            User? user = db.Users.Find(id);
            if (user == null)
            {
                return null;
            }

            user.Contacts = new List<ContactApi>(db.Contacts.Where(contact => contact.contactOf == user.Id));
            return user;
        }
    }

    // this method will return the last id in the users list

    public void Update(string id)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }

    public bool Auth(string username, string pass)
    {
        User? userFound = Get(username);
        if (userFound != null)
        {
            if (userFound.Password == pass)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public void UpdateLastMessage(string myId, string idFriend, string mess, string time)
    {
        using (var db = new ChatDbContext())
        {
            ContactApi? friend =
                db.Contacts.FirstOrDefault(contact => contact.contactOf == myId && contact.Id == idFriend);
            if (friend == null)
            {
                return;
            }

            friend.last = mess;
            friend.lastdate = time;
            db.Contacts.Update(friend);
            db.SaveChanges();
        }
    }
}