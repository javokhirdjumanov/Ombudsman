using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using DomainLayer.Entities.ENUM;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.INFO;
[Table(TableNames.Organization)]
public class Organization : AudiTable
{
    /// <summary>
    /// DAVLAT TASHKILOTI TOIFASI
    /// </summary>
    public int StateOrganizationIds { get; set; }
    [ForeignKey(nameof(StateOrganizationIds))]
    public StateOrganization StateOrganization { get; set; }

    /// <summary>
    /// GURUHLOVCHI
    /// </summary>
    public bool IsGrouper { get; set; }

    /// <summary>
    /// YUQORI TURUVCHI TASHKILOT
    /// </summary>
    public int? OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public Organization? SuperiorOrganization { get; set; }

    public int StateId { get; set; }
    [ForeignKey(nameof(StateId))]
    public State State { get; set; }
}
