namespace chatServer.Models;

public class User
{
    public int UserId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Pic { get; set; }

    public List<Contact> Contacts { get; set; }
}