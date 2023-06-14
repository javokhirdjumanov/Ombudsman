using DomainLayer.Constants;
using DomainLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities.ENUM;
[Table(TableNames.StateOrganizationTranslate)]
public class StateOrganizationTranslate : EntityTranslate
{
    public int StateOrganizationId { get; set; }
    [ForeignKey(nameof(StateOrganizationId))]
    public StateOrganization StateOrganization { get; set; }
}
