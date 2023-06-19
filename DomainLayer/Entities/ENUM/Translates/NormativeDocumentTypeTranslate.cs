using DomainLayer.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.NormativeDocumentTranslate)]
[Index("LanguageId", Name = "ix_enum_normative_document_translate_language_id")]
[Index("OwnerId", Name = "ix_enum_normative_document_translate_owner_id")]
public class NormativeDocumentTypeTranslate
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
    [InverseProperty("NormativeDocumentTranslates")]
    public virtual Language Language { get; set; } = null!;
    [ForeignKey("OwnerId")]
    [InverseProperty("NormativeDocumentTranslates")]
    public virtual NormativeDocumentType Owner { get; set; } = null!;
}
