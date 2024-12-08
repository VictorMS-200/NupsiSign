namespace NupsiSign.Models.DbSet;

public class Groom : Couple
{
    public Guid? Id { get; set; }
    public virtual Data? Data { get; set; }
}