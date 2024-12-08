

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NupsiSign.Models.DbSet;

namespace AcademicShare.Web.Context;


public class NupsiSignDbContext : IdentityDbContext<User>
{
    public NupsiSignDbContext(DbContextOptions<NupsiSignDbContext> options) : base(options) { }
    
    public override DbSet<User> Users { get; set; }
    public DbSet<Data> Data { get; set; }
    
    public DbSet<DocumentationClass> Documentations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Data>()
            .HasKey(d => d.Id);
        
        modelBuilder.Entity<Data>()
            .HasOne(d => d.Groom)
            .WithOne(g => g.Data)
            .HasForeignKey<Data>(d => d.GroomId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Data>()
            .HasOne(d => d.Bride)
            .WithOne(b => b.Data)
            .HasForeignKey<Data>(d => d.BrideId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Data>()
            .HasOne(d => d.FirstWitness)
            .WithOne(f => f.Data)
            .HasForeignKey<Data>(d => d.FirstWitnessId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Data>()
            .HasOne(d => d.SecondWitness)
            .WithOne(s => s.Data)
            .HasForeignKey<Data>(d => d.SecondWitnessId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<DocumentationClass>()
            .HasKey(d => d.Id);
                
        
        base.OnModelCreating(modelBuilder);
    }
}
