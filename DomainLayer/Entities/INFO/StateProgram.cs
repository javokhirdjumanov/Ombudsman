using DomainLayer.Entities.DOC;
using DomainLayer.Entities.ENUM;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.INFO;
[Table("info_state_program", Schema = "public")]
[Index("StateId", Name = "ix_info_state_program_state_id")]
public class StateProgram
{
    public StateProgram()
    {
        Documents = new HashSet<Document>();
        InformationLetters = new HashSet<InformationLetter>();
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
    [InverseProperty("StatePrograms")]
    public virtual State State { get; set; } = null!;
    [InverseProperty("StateProgram")]
    public virtual ICollection<Document> Documents { get; set; }
    [InverseProperty("StateProgram")]
    public virtual ICollection<InformationLetter> InformationLetters { get; set; }
}
