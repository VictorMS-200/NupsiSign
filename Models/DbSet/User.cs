using Microsoft.AspNetCore.Identity;

namespace NupsiSign.Models.DbSet;

public class User : IdentityUser
{
    public DateTime CreateAt { get; set; }
}