using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
/// <summary>
/// MEYORIY HUJJAT TURI
/// </summary>
[Table(TableNames.NormativeDocument)]
public class NormativeDocumentType : BaseEnumTable
{
    public string ShortCharacter { get; set; }

    public int StateId { get; set; }
    [ForeignKey(nameof(StateId))]
    public State State { get; set; }
}
