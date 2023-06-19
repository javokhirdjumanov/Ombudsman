using DomainLayer.Constants;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;

/// <summary>
/// DAVLAT TASHKILOTI TOIFASI
/// </summary>
[Table(TableNames.StateOrganization)]
[Index("StateId", Name = "ix_enum_state_organization_state_id")]
public class StateOrganization
{
    public StateOrganization()
    {
        StateOrganizationTranslates = new HashSet<StateOrganizationTranslate>();
        Organizations = new HashSet<Organization>();
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
    [InverseProperty("StateOrganizations")]
    public virtual State State { get; set; } = null!;
    [InverseProperty("Owner")]
    public virtual ICollection<StateOrganizationTranslate> StateOrganizationTranslates { get; set; }
    [InverseProperty("StateOrganizationIdsNavigation")]
    public virtual ICollection<Organization> Organizations { get; set; }
}
