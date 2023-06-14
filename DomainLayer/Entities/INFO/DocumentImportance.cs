using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using DomainLayer.Entities.ENUM;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace DomainLayer.Entities.INFO;
[Table("info_document_importance", Schema = "public")]
public class DocumentImportance : AudiTable     // hujjat ahamiyati
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
