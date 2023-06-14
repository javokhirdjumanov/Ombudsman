using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;

/// <summary>
/// HUJJAT HOLATI
/// </summary>
[Table(TableNames.DocumentStatus)]
public class DocumentStatus : AudiTable
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
