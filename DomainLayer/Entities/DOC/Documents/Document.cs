using DomainLayer.Constants;
using DomainLayer.Entities.DOC.Files;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.HL;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.DOC;
[Table(TableNames.Documents)]
[Index("DocumentImportanceId", Name = "ix_doc_documents_document_importance_id")]
[Index("DocumentStatusId", Name = "ix_doc_documents_document_status_id")]
[Index("FileId", Name = "ix_doc_documents_file_id")]
[Index("InitiativeTypeId", Name = "ix_doc_documents_initiative_type_id")]
[Index("NormativeDocumentId", Name = "ix_doc_documents_normative_document_id")]
[Index("OrganizationId", Name = "ix_doc_documents_organization_id")]
[Index("OrginizationUserId", Name = "ix_doc_documents_orginization_user_id")]
[Index("SectorId", Name = "ix_doc_documents_sector_id")]
[Index("StateProgramId", Name = "ix_doc_documents_state_program_id")]
public class Document
{
    public Document()
    {
        InformationLetters = new HashSet<InformationLetter>();
        VisaHolders = new HashSet<VisaHolders>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("order_number")]
    public int OrderNumber { get; set; }
    [Column("normative_document_id")]
    public int NormativeDocumentId { get; set; }
    [Column("document_importance_id")]
    public int DocumentImportanceId { get; set; }
    [Column("state_program_included")]
    public bool StateProgramIncluded { get; set; }
    [Column("state_program_id")]
    public int? StateProgramId { get; set; }
    [Column("document_name")]
    public string? DocumentName { get; set; }
    [Column("document_content")]
    public string? DocumentContent { get; set; }
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; } = DateTime.Now;
    [Column("send_document_data", TypeName = "timestamp without time zone")]
    public DateTime? SendDocumentData { get; set; }
    [Column("estimated_execution_time", TypeName = "timestamp without time zone")]
    public DateTime? EstimatedExecutionTime { get; set; }
    [Column("sector_id")]
    public int? SectorId { get; set; }
    [Column("main_ministry")]
    public string? MainMinistry { get; set; }
    [Column("orginization_user_id")]
    public int OrginizationUserId { get; set; }
    [Column("initiative_type_id")]
    public int InitiativeTypeId { get; set; }
    [Column("performers")]
    public string Performers { get; set; } = null!;
    [Column("organization_id")]
    public int OrganizationId { get; set; }
    [Column("document_status_id")]
    public int DocumentStatusId { get; set; }
    [Column("normative_doc_number")]
    public int? NormativeDocNumber { get; set; }
    [Column("normative_doc_date", TypeName = "timestamp without time zone")]
    public DateTime? NormativeDocDate { get; set; }
    [Column("file_id")]
    public int? FileId { get; set; }
    [ForeignKey("DocumentImportanceId")]
    [InverseProperty("Documents")]
    public virtual DocumentImportance DocumentImportance { get; set; } = null!;
    [ForeignKey("DocumentStatusId")]
    [InverseProperty("Documents")]
    public virtual DocumentStatus DocumentStatus { get; set; } = null!;
    [ForeignKey("FileId")]
    [InverseProperty("Documents")]
    public virtual FileModel? File { get; set; }
    [ForeignKey("InitiativeTypeId")]
    [InverseProperty("Documents")]
    public virtual InitiativeType InitiativeType { get; set; } = null!;
    [ForeignKey("NormativeDocumentId")]
    [InverseProperty("Documents")]
    public virtual NormativeDocumentType NormativeDocument { get; set; } = null!;
    [ForeignKey("OrganizationId")]
    [InverseProperty("Documents")]
    public virtual Organization Organization { get; set; } = null!;
    [ForeignKey("OrginizationUserId")]
    [InverseProperty("Documents")]
    public virtual User OrginizationUser { get; set; } = null!;
    [ForeignKey("SectorId")]
    [InverseProperty("Documents")]
    public virtual Sector? Sector { get; set; }
    [ForeignKey("StateProgramId")]
    [InverseProperty("Documents")]
    public virtual StateProgram? StateProgram { get; set; }
    [InverseProperty("Document")]
    public virtual ICollection<InformationLetter> InformationLetters { get; set; }
    [InverseProperty("Document")]
    public virtual ICollection<VisaHolders> VisaHolders { get; set; }
}