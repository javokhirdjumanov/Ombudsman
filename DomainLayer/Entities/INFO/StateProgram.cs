using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using DomainLayer.Entities.ENUM;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.INFO;
[Table("info_state_program", Schema = "public")]
public class StateProgram : AudiTable        // DAVLAT DASTURI
{
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
}
