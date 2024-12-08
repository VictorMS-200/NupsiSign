using System.ComponentModel.DataAnnotations.Schema;

namespace NupsiSign.Models.DbSet;

public class DocumentationClass
{
    public Guid? Id { get; set; }
    public virtual User? User { get; set; }
    public string? BirthCertificate { get; set; }
    
    [NotMapped]
    public IFormFile? BirthCertificateFile { get; set; }
    public string? IdentificationGuardians { get; set; }
    [NotMapped]
    public IFormFile? IdentificationGuardiansFile { get; set; }
    public string? MarriageCertificate { get; set; }
    [NotMapped]
    public IFormFile? MarriageCertificateFile { get; set; }
    public string? InitialPetition { get; set; }
    [NotMapped]
    public IFormFile? InitialPetitionFile { get; set; }
    public string? AddressProofDocumentation { get; set; }
    [NotMapped]
    public IFormFile? AddressProofDocumentationFile { get; set; }
}