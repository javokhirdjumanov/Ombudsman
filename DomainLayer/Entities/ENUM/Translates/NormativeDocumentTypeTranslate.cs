using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.NormativeDocumentTranslate)]
public class NormativeDocumentTypeTranslate : EntityTranslate
{
    public int owner_id { get; set; }
    [ForeignKey(nameof(owner_id))]
    public NormativeDocumentType NormativeDocumentType { get; set; }
}
