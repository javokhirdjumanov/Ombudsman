using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.StateTranslate)]
public class StateTranslate : EntityTranslate
{
    public int owner_id { get; set; }
    [ForeignKey(nameof(owner_id))]
    public State State { get; set; }
}
