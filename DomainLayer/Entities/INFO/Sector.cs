using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using DomainLayer.Entities.ENUM;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.INFO;
[Table(TableNames.Sectors)]
[Index("StateId", Name = "ix_info_sectors_state_id")]

public class Sector
{
    public Sector()
    {
        Documents = new HashSet<Document>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("sector_number")]
    public int SectorNumber { get; set; }
    [Column("state_id")]
    public int StateId { get; set; }
    [Column("order_number")]
    public int OrderNumber { get; set; }
    [Column("short_name")]
    public string? ShortName { get; set; }
    [Column("full_name")]
    public string? FullName { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("Sectors")]
    public virtual State State { get; set; } = null!;
    [InverseProperty("Sector")]
    public virtual ICollection<Document> Documents { get; set; }
}
