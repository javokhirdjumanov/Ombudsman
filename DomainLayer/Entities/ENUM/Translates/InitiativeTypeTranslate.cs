using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.InitiativeTypeTranslate)]
public class InitiativeTypeTranslate : EntityTranslate
{
    public int InitiativeTypeId { get; set; }
    [ForeignKey(nameof(InitiativeTypeId))]
    public InitiativeType InitiativeType { get; set; }
}
