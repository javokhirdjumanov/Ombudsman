using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities;
public abstract class AudiTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
}
