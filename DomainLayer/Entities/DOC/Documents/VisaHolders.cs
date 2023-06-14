using DomainLayer.Constants;
using DomainLayer.Entities.INFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.DOC;
[Table(TableNames.VisaHoldersForDoc)]
public class VisaHolders
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Qaysi hujjat
    /// </summary>
    public int DocumentId { get; set; }
    [ForeignKey(nameof(DocumentId))]
    [InverseProperty(nameof(Document.VisaHolders))]
    public Document HolderDocument { get; set; }
    public int OrderNumber { get; set; }

    /// <summary>
    /// QAYSI HAT GA TEGISHLI
    /// </summary>
    public int? InformationLetterId { get; set; }
    [ForeignKey(nameof(InformationLetterId))]
    [InverseProperty(nameof(InformationLetter.VisaHolders))]
    public InformationLetter? HolderInformationLetter { get; set; }

    /// <summary>
    /// Tashkilot
    /// </summary>
    public int OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public Organization Organization { get; set; }

    /// <summary>
    /// Visa quyuvchi
    /// </summary>
    public string FIO { get; set; }

    /// <summary>
    /// Lavozimi
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// Masul xodim
    /// </summary>
    public string ResponsibleEmployee { get; set; }

    /// <summary>
    /// Telefon raqam
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Kiritilgan sana
    /// </summary>
    public DateTime CreateAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Viza quyilgan sana
    /// </summary>
    public DateTime DateVisaAddition { get; set; }
}
