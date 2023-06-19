using DomainLayer.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
/// <summary>
/// IJROCHI TURI
/// </summary>
[Table(TableNames.PerformerType)]
[Index("StateId", Name = "ix_enum_performer_type_state_id")]
public class PerformerType
{
    public PerformerType()
    {
        PerformerTypeTranslates = new HashSet<PerformerTypeTranslate>();
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
    [InverseProperty("PerformerTypes")]
    public virtual State State { get; set; } = null!;
    [InverseProperty("Owner")]
    public virtual ICollection<PerformerTypeTranslate> PerformerTypeTranslates { get; set; }
}
