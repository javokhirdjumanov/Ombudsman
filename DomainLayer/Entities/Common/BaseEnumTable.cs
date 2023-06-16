using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.Common;
public abstract class BaseEnumTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
}
