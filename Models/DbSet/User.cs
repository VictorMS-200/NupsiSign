using Microsoft.AspNetCore.Identity;

namespace NupsiSign.Models.DbSet;

public class User : IdentityUser
{
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public Guid? DataId { get; set; }
    public virtual Data? Data { get; set; }
    public Guid? DocumentationId { get; set; }
    public virtual DocumentationClass? Documentation { get; set; }
}