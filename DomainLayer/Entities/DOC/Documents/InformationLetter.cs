using DomainLayer.Constants;
using DomainLayer.Entities.INFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.DOC;
[Table(TableNames.InformationLetter)]
public class InformationLetter
{
    public InformationLetter()
    {
        VisaHolders = new HashSet<VisaHolders>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("information_letter_number")]
    public int InformationLetterNumber { get; set; }
    [Column("information_letter_date", TypeName = "timestamp without time zone")]
    public DateTime InformationLetterDate { get; set; } = DateTime.Now;
    [Column("visa_holder")]
    public string VisaHolder { get; set; } = null!;
    [Column("information_letter_text")]
    public string InformationLetterText { get; set; } = null!;
    [Column("state_program_id")]
    public int StateProgramId { get; set; }
    [Column("employee_id")]
    public int EmployeeId { get; set; }
    [Column("responsible_employee")]
    public string ResponsibleEmployee { get; set; } = null!;
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;
    [Column("document_id")]
    public int DocumentId { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("InformationLetters")]
    public virtual Document Document { get; set; } = null!;
    [ForeignKey("EmployeeId")]
    [InverseProperty("InformationLetters")]
    public virtual Employee Employee { get; set; } = null!;
    [ForeignKey("StateProgramId")]
    [InverseProperty("InformationLetters")]
    public virtual StateProgram StateProgram { get; set; } = null!;
    [InverseProperty("InformationLetter")]
    public virtual ICollection<VisaHolders>? VisaHolders { get; set; }
}
