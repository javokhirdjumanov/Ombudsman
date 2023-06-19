using DomainLayer.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.PerformerTypeTranslate)]
[Index("LanguageId", Name = "ix_enum_performer_type_translate_language_id")]
[Index("OwnerId", Name = "ix_enum_performer_type_translate_owner_id")]
public class PerformerTypeTranslate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("owner_id")]
    public int OwnerId { get; set; }
    [Column("language_id")]
    public int LanguageId { get; set; }
    [Column("column_name")]
    public string ColumnName { get; set; } = null!;
    [Column("translate_text")]
    public string TranslateText { get; set; } = null!;

    [ForeignKey("LanguageId")]
    [InverseProperty("PerformerTypeTranslates")]
    public virtual Language Language { get; set; } = null!;
    [ForeignKey("OwnerId")]
    [InverseProperty("PerformerTypeTranslates")]
    public virtual PerformerType Owner { get; set; } = null!;
}
