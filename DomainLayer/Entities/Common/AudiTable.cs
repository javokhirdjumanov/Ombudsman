using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities.Common;
public abstract class AudiTable
{
    [Key]
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
}
