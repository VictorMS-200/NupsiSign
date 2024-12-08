namespace NupsiSign.Models.DbSet;

public class Bride : Couple
{
    public Guid? Id { get; set; }
    public virtual Data? Data { get; set; }
}