using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
/// <summary>
/// MEYORIY HUJJAT TURI
/// </summary>
[Table(TableNames.NormativeDocument)]
[Index("StateId", Name = "ix_enum_normative_document_state_id")]
public class NormativeDocumentType
{
    public NormativeDocumentType()
    {
        Documents = new HashSet<Document>();
        NormativeDocumentTranslates = new HashSet<NormativeDocumentTypeTranslate>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("short_character")]
    public string ShortCharacter { get; set; } = null!;
    [Column("state_id")]
    public int StateId { get; set; }
    [Column("order_number")]
    public int OrderNumber { get; set; }
    [Column("short_name")]
    public string? ShortName { get; set; }
    [Column("full_name")]
    public string? FullName { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("NormativeDocumentsTypes")]
    public virtual State State { get; set; } = null!;
    [InverseProperty("NormativeDocument")]
    public virtual ICollection<Document> Documents { get; set; }
    [InverseProperty("Owner")]
    public virtual ICollection<NormativeDocumentTypeTranslate> NormativeDocumentTranslates { get; set; }
}
