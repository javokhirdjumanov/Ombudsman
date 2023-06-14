using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;

/// <summary>
/// DAVLAT TASHKILOTI TOIFASI
/// </summary>
[Table(TableNames.StateOrganization)]
public class StateOrganization : AudiTable
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
