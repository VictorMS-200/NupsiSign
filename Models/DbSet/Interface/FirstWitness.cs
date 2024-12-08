namespace NupsiSign.Models.DbSet;

public class FirstWitness : Witness
{
    public Guid? Id { get; set; }
    public virtual Data? Data { get; set; }
}