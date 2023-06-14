using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.PerformerTypeTranslate)]
public class PerformerTypeTranslate : EntityTranslate
{
    public int PerformerTypeId { get; set; }
    [ForeignKey(nameof(PerformerTypeId))]
    public PerformerType PerformerType { get; set; }
}
