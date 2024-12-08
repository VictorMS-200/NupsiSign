namespace NupsiSign.Models.DbSet;

public class SecondWitness : Witness
{
    public Guid? Id { get; set; }
    public virtual Data? Data { get; set; }
}