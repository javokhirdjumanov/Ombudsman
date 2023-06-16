using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.InitiativeTypeTranslate)]
public class InitiativeTypeTranslate : EntityTranslate
{
    public int owner_id { get; set; }
    [ForeignKey(nameof(owner_id))]
    public InitiativeType InitiativeType { get; set; }
}
