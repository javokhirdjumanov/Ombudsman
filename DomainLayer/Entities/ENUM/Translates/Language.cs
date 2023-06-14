using DomainLayer.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.Language)]
public class Language
{
    [Key]
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
}
