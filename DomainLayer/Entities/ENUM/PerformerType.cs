using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
/// <summary>
/// IJROCHI TURI
/// </summary>
[Table(TableNames.PerformerType)]
public class PerformerType : BaseEnumTable
{
    public int StateId { get; set; }
    [ForeignKey(nameof(StateId))]
    public State State { get; set; }
}
