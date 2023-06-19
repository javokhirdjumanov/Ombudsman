using DomainLayer.Constants;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.DOC;
[Table(TableNames.VisaHoldersForDoc)]
[Index("DocumentId", Name = "ix_doc_visa_holders_for_doc_document_id")]
[Index("InformationLetterId", Name = "ix_doc_visa_holders_for_doc_information_letter_id")]
[Index("OrganizationId", Name = "ix_doc_visa_holders_for_doc_organization_id")]
public class VisaHolders
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("document_id")]
    public int? DocumentId { get; set; }
    [Column("order_number")]
    public int OrderNumber { get; set; }
    [Column("information_letter_id")]
    public int? InformationLetterId { get; set; }
    [Column("organization_id")]
    public int OrganizationId { get; set; }
    [Column("fio")]
    public string Fio { get; set; } = null!;
    [Column("position")]
    public string Position { get; set; } = null!;
    [Column("responsible_employee")]
    public string ResponsibleEmployee { get; set; } = null!;
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; } = DateTime.Now;
    [Column("date_visa_addition", TypeName = "timestamp without time zone")]
    public DateTime DateVisaAddition { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("VisaHolders")]
    public virtual Document Document { get; set; } = null!;
    [ForeignKey("InformationLetterId")]
    [InverseProperty("VisaHolders")]
    public virtual InformationLetter? InformationLetter { get; set; }
    [ForeignKey("OrganizationId")]
    [InverseProperty("VisaHolders")]
    public virtual Organization Organization { get; set; } = null!;
}
