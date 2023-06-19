namespace ServiceLayer.Services;
public class OrgDto
{
    public int id { get; set; }
    public int ordernumber { get; set; }
    public StateOrganizationDto? stateOrganizationIdsNavigation { get; set; }
    public bool isGrouper { get; set; }
    public OrgDto? superiorOrganization { get; set; }
    public string? shortName { get; set; }
    public string? fullName { get; set; }
    public StateDto? state { get; set; }
}
