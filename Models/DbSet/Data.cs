namespace NupsiSign.Models.DbSet;

public class Data 
{
    public Guid? Id { get; set; }
    public string? marrigeCelebrated { get; set; }
    public string? propertyRegime { get; set; }
    public Guid? GroomId { get; set; }
    public virtual Groom? Groom { get; set; }
    public Guid? BrideId { get; set; }
    public virtual Bride? Bride { get; set; }
    public Guid? FirstWitnessId { get; set; }
    public virtual FirstWitness? FirstWitness { get; set; }
    public Guid? SecondWitnessId { get; set; }
    public virtual SecondWitness? SecondWitness { get; set; }
    public virtual User? User { get; set; }
}