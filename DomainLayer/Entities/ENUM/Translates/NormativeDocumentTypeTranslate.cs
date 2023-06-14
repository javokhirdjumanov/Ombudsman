using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.NormativeDocumentTranslate)]
public class NormativeDocumentTypeTranslate : EntityTranslate
{
    public int NormativeDocumentTypeId { get; set; }
    [ForeignKey(nameof(NormativeDocumentTypeId))]
    public NormativeDocumentType NormativeDocumentType { get; set; }
}
