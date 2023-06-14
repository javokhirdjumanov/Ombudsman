using DomainLayer.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
/// <summary>
/// TASHABBUS TURI
/// </summary>
[Table(TableNames.InitiativeType)]
public class InitiativeType
{
    [Key]
    public int Id { get; set; }
    public string Names { get; set; }
}
