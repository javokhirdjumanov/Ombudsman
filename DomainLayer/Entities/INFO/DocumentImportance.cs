using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using DomainLayer.Entities.ENUM;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace DomainLayer.Entities.INFO;

/// <summary>
/// Hujjat Ahamiyati
/// </summary>
[Table(TableNames.DocumentImportance)]
public class DocumentImportance : AudiTable
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
