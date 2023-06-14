using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using DomainLayer.Entities.ENUM;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.INFO;
/// <summary>
/// Davlat dasturi
/// </summary>
[Table(TableNames.StateProgram)]
public class StateProgram : AudiTable
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
