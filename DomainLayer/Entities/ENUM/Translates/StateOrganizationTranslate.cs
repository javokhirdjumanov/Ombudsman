using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.StateOrganizationTranslate)]
public class StateOrganizationTranslate : EntityTranslate
{
    public int owner_id { get; set; }
    [ForeignKey(nameof(owner_id))]
    public StateOrganization StateOrganization { get; set; }
}
