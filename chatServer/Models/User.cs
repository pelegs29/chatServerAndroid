namespace chatServer.Models;

public class User
{
    public int Id { get; set; } //this is the UserId

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Pic { get; set; }

    public List<Contact> Contacts { get; set; }
}