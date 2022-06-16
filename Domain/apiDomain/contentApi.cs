using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.apiDomain;

public class ContentApi
{
    [Key] public int? Id { get; set; }
    public string? Content { get; set; }
    public string? Created { get; set; }
    public bool? Sent { get; set; }
}