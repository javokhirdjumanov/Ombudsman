using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;

/// <summary>
/// HUJJAT HOLATI
/// </summary>
[Table(TableNames.DocumentStatus)]
[Index("StatusId", Name = "ix_enum_document_status_status_id")]
public class DocumentStatus
{
    public DocumentStatus()
    {
        Documents = new HashSet<Document>();
        DocumentStatusTranslates = new HashSet<DocumentStatusTranslate>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("status_id")]
    public int StatusId { get; set; }
    [Column("order_number")]
    public int OrderNumber { get; set; }
    [Column("short_name")]
    public string? ShortName { get; set; }
    [Column("full_name")]
    public string? FullName { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("DocumentStatuses")]
    public virtual State Status { get; set; } = null!;
    [InverseProperty("DocumentStatus")]
    public virtual ICollection<Document> Documents { get; set; }
    [InverseProperty("Owner")]
    public virtual ICollection<DocumentStatusTranslate> DocumentStatusTranslates { get; set; }
}
