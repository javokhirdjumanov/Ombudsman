using DomainLayer.Constants;
using DomainLayer.Entities.DOC.Files;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.HL;
using DomainLayer.Entities.INFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.DOC;
[Table(TableNames.Documents)]
public class Document
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Tartib raqam
    /// </summary>
    public int OrderNumber { get; set; }

    /// <summary>
    ///  Hujjat turi
    /// </summary>
    public int NormativeDocumentId { get; set; }
    [ForeignKey(nameof(NormativeDocumentId))]
    public NormativeDocumentType NormativeDocument { get; set; }

    /// <summary>
    ///  Hujjat Ahamiyati
    /// </summary>
    public int DocumentImportanceId { get; set; }
    [ForeignKey(nameof(DocumentImportanceId))]
    public DocumentImportance DocumentImportance { get; set; }

    /// <summary>
    /// Davlat dasturiga qo'shilganmi yo'qmi
    /// </summary>
    public bool StateProgramIncluded { get; set; }

    /// <summary>
    /// Davlat dasturi
    /// </summary>
    public int? StateProgramId { get; set; }
    [ForeignKey(nameof(StateProgramId))]
    public StateProgram? StateProgram { get; set; }

    /// <summary>
    /// Hujjat nomi
    /// </summary>
    public string? DocumentName { get; set; }

    /// <summary>
    /// Hujjat qisqacha mazmuni
    /// </summary>
    public string? DocumentContent { get; set; }

    /// <summary>
    /// Hujjat yaratilgan Sana
    /// </summary>
    public DateTime CreateAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Hujjat jo'natilgan sana
    /// </summary>
    public DateTime? SendDocumentData { get; set; }

    /// <summary>
    /// Taxminiy ijro muddati
    /// </summary>
    public DateTime? EstimatedExecutionTime { get; set; }

    /// <summary>
    /// Sektor
    /// </summary>
    public int? SectorId { get; set; }
    [ForeignKey(nameof(SectorId))]
    public Sectors? Sector { get; set; }

    /// <summary>
    /// Asosiy vazirlk
    /// </summary>
    public string? MainMinistry { get; set; }

    /// <summary>
    /// Asosiy Ijrochi
    /// </summary>
    public int OrginizationUserId { get; set; }
    [ForeignKey(nameof(OrginizationUserId))]
    public User User{ get; set; }

    /// <summary>
    /// Tashabbus turi
    /// </summary>
    public int InitiativeTypeId { get; set; }
    [ForeignKey(nameof(InitiativeTypeId))]
    public InitiativeType InitiativeType { get; set; }

    /// <summary>
    /// Ham Ijrochilar
    /// </summary>
    public string Performers { get; set; }

    /// <summary>
    /// Tashabbuskor
    /// </summary>
    public int OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public Organization Organization { get; set; }

    /// <summary>
    /// Hujjat holati
    /// </summary>
    public int DocumentStatusId { get; set; }
    [ForeignKey(nameof(DocumentStatusId))]
    public DocumentStatus DocumentStatus { get; set; }

    /// <summary>
    /// Meyoriy hujjat raqami
    /// </summary>
    public int? NormativeDocNumber { get; set; }

    /// <summary>
    /// Meyoriy hujjat sanasi
    /// </summary>
    public DateTime? NormativeDocDate { get; set; }

    /// <summary>
    /// Axborot xati
    /// </summary>
    public int? InformationLetterId { get; set; }
    [ForeignKey(nameof(InformationLetterId))]
    public InformationLetter? InformationLetter { get; set; }

    /// <summary>
    /// File
    /// </summary>
    public int? FileId { get; set; }
    [ForeignKey(nameof(FileId))]
    public FileModel? Files { get; set; }

    public ICollection<VisaHolders> VisaHolders { get; set; }
}
