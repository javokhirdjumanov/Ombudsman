using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;

namespace ServiceLayer.Services;
public class OrgDto
{
    public int id { get; set; }
    public int order_number { get; set; }
    public StateOrganization state_organization{ get; set; }
    public bool is_grouper { get; set; }
    public Organization? supreor_organization { get; set; }
    public string? short_name { get; set; }
    public string? full_name { get; set; }
    public State status { get; set; }
}
