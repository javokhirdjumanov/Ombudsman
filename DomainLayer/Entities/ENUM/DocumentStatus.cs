using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;

/// <summary>
/// HUJJAT HOLATI
/// </summary>
[Table(TableNames.DocumentStatus)]
public class DocumentStatus : BaseEnumTable
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public State State { get; set; }
}
