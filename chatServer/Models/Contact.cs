using System.ComponentModel.DataAnnotations;

namespace chatServer.Models;

public class Contact
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string LastMessage { get; set; }
}