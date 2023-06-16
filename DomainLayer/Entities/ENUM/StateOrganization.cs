using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;

/// <summary>
/// DAVLAT TASHKILOTI TOIFASI
/// </summary>
[Table(TableNames.StateOrganization)]
public class StateOrganization : BaseEnumTable
{
    public int StateId { get; set; }
    [ForeignKey(nameof(StateId))]
    public State State { get; set; }
}
