

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NupsiSign.Models.DbSet;

namespace AcademicShare.Web.Context;


public class NupsiSignDbContext : IdentityDbContext<User>
{
    public NupsiSignDbContext(DbContextOptions<NupsiSignDbContext> options) : base(options) { }
    
    public override DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
