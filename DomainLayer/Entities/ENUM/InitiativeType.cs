using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
/// <summary>
/// TASHABBUS TURI
/// </summary>
[Table(TableNames.InitiativeType)]
public class InitiativeType
{
    public InitiativeType()
    {
        Documents = new HashSet<Document>();
        InitiativeTypeTranslates = new HashSet<InitiativeTypeTranslate>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("names")]
    public string Names { get; set; } = null!;

    [InverseProperty("InitiativeType")]
    public virtual ICollection<Document> Documents { get; set; }
    [InverseProperty("Owner")]
    public virtual ICollection<InitiativeTypeTranslate> InitiativeTypeTranslates { get; set; }
}
