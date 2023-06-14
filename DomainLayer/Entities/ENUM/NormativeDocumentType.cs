using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
/// <summary>
/// MEYORIY HUJJAT TURI
/// </summary>
[Table(TableNames.NormativeDocument)]
public class NormativeDocumentType : AudiTable
{
    public string ShortCharacter { get; set; }

    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
