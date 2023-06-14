using DomainLayer.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.DOC.Files;
[Table(TableNames.FileModel)]
public class FileModel
{
    [Key]
    public int Id { get; set; }
    public string Type { get; set; }
    public string FileName { get; set; }
}
