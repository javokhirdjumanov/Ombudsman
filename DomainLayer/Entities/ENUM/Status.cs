using DomainLayer.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.Status)]
public class Status
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
