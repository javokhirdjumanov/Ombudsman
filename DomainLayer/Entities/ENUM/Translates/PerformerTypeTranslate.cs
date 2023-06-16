using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.PerformerTypeTranslate)]
public class PerformerTypeTranslate : EntityTranslate
{
    public int owner_id { get; set; }
    [ForeignKey(nameof(owner_id))]
    public PerformerType PerformerType { get; set; }
}
