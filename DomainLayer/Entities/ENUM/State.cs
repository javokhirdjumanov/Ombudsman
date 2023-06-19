using DomainLayer.Constants;
using DomainLayer.Entities.INFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.State)]
public class State
{
    public State()
    {
        DocumentStatuses = new HashSet<DocumentStatus>();
        NormativeDocumentsTypes = new HashSet<NormativeDocumentType>();
        PerformerTypes = new HashSet<PerformerType>();
        StateOrganizations = new HashSet<StateOrganization>();
        StateTranslates = new HashSet<StateTranslate>();
        DocumentImportances = new HashSet<DocumentImportance>();
        Organizations = new HashSet<Organization>();
        Sectors = new HashSet<Sector>();
        StatePrograms = new HashSet<StateProgram>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<DocumentStatus> DocumentStatuses { get; set; }
    [InverseProperty("State")]
    public virtual ICollection<NormativeDocumentType> NormativeDocumentsTypes { get; set; }
    [InverseProperty("State")]
    public virtual ICollection<PerformerType> PerformerTypes { get; set; }
    [InverseProperty("State")]
    public virtual ICollection<StateOrganization> StateOrganizations { get; set; }
    [InverseProperty("Owner")]
    public virtual ICollection<StateTranslate> StateTranslates { get; set; }
    [InverseProperty("State")]
    public virtual ICollection<DocumentImportance> DocumentImportances { get; set; }
    [InverseProperty("State")]
    public virtual ICollection<Organization> Organizations { get; set; }
    [InverseProperty("State")]
    public virtual ICollection<Sector> Sectors { get; set; }
    [InverseProperty("State")]
    public virtual ICollection<StateProgram> StatePrograms { get; set; }
}
