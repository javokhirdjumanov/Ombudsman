using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.StatusTranslate)]
public class StatusTranslate : EntityTranslate
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
