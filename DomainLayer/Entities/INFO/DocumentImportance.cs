using DomainLayer.Entities.DOC;
using DomainLayer.Entities.ENUM;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.INFO;
[Table("info_document_importance", Schema = "public")]
[Index("StateId", Name = "ix_info_document_importance_state_id")]
public class DocumentImportance
{
    public DocumentImportance()
    {
        Documents = new HashSet<Document>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("state_id")]
    public int StateId { get; set; }
    [Column("order_number")]
    public int OrderNumber { get; set; }
    [Column("short_name")]
    public string? ShortName { get; set; }
    [Column("full_name")]
    public string? FullName { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("DocumentImportances")]
    public virtual State State { get; set; } = null!;
    [InverseProperty("DocumentImportance")]
    public virtual ICollection<Document> Documents { get; set; }
}
