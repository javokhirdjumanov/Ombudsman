using DomainLayer.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.DOC.Files;
[Table(TableNames.FileModel)]
public class FileModel
{
    public FileModel()
    {
        Documents = new HashSet<Document>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("type")]
    public string Type { get; set; } = null!;
    [Column("file_name")]
    public string FileName { get; set; } = null!;

    [InverseProperty("File")]
    public virtual ICollection<Document> Documents { get; set; }
}
