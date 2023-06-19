using DomainLayer.Constants;
using DomainLayer.Entities.HL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.Language)]
public class Language
{
    public Language()
    {
        DocumentStatusTranslates = new HashSet<DocumentStatusTranslate>();
        InitiativeTypeTranslates = new HashSet<InitiativeTypeTranslate>();
        NormativeDocumentTranslates = new HashSet<NormativeDocumentTypeTranslate>();
        PerformerTypeTranslates = new HashSet<PerformerTypeTranslate>();
        StateOrganizationTranslates = new HashSet<StateOrganizationTranslate>();
        StateTranslates = new HashSet<StateTranslate>();
        Users = new HashSet<User>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("short_name")]
    public string ShortName { get; set; } = null!;
    [Column("full_name")]
    public string FullName { get; set; } = null!;

    [InverseProperty("Language")]
    public virtual ICollection<DocumentStatusTranslate> DocumentStatusTranslates { get; set; }
    [InverseProperty("Language")]
    public virtual ICollection<InitiativeTypeTranslate> InitiativeTypeTranslates { get; set; }
    [InverseProperty("Language")]
    public virtual ICollection<NormativeDocumentTypeTranslate> NormativeDocumentTranslates { get; set; }
    [InverseProperty("Language")]
    public virtual ICollection<PerformerTypeTranslate> PerformerTypeTranslates { get; set; }
    [InverseProperty("Language")]
    public virtual ICollection<StateOrganizationTranslate> StateOrganizationTranslates { get; set; }
    [InverseProperty("Language")]
    public virtual ICollection<StateTranslate> StateTranslates { get; set; }
    [InverseProperty("Language")]
    public virtual ICollection<User> Users { get; set; }
}
