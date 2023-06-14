using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.DocumentStatusTranslate)]
public class DocumentStatusTranslate : EntityTranslate
{
    public int DocumentStatusId { get; set; }
    [ForeignKey(nameof(DocumentStatusId))]
    public DocumentStatus DocumentStatus { get; set; }
}
