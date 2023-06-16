using DomainLayer.Entities.ENUM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.Common;
public abstract class EntityTranslate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int LanguageId { get; set; }
    [ForeignKey(nameof(LanguageId))]
    public Language Languages{ get; set; }

    public string ColumnName { get; set; }
    public string TranslateText { get; set; }
}
