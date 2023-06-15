using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;

namespace ServiceLayer.Services;
public class FactoryOrganization : IFactoryOrganization
{
    public Organization MapToOrganization(
        OrgDlDto orgDlDto,
        StateOrganization stateOrg,
        Organization? child_organization,
        Status status)
    {
        var newOrganization = new Organization
        {
            OrderNumber = orgDlDto.order_number,
            StateOrganization = stateOrg,
            IsGrouper = orgDlDto.is_grouper,
            SuperiorOrganization = child_organization,
            ShortName = orgDlDto.short_name,
            FullName = orgDlDto.full_name,
            Status = status
        };

        return newOrganization;
    }

    public void MapToOrganization(Organization organization, OrgDlDtoForModify orgDlDtoForModify)
    {
        organization.OrderNumber = orgDlDtoForModify.order_number;
        organization.OrganizationId = orgDlDtoForModify.organization_id;
        organization.IsGrouper = orgDlDtoForModify.is_grouper;
        organization.FullName = orgDlDtoForModify.full_name;
        organization.ShortName = orgDlDtoForModify.short_name;
        organization.StatusId = orgDlDtoForModify.status_id;
        organization.StateOrganizationId = orgDlDtoForModify.state_organization_id;
    }

    public OrgDto MapToOrganizationDto(Organization addedOrganization)
    {
        return new OrgDto
        {
            id = addedOrganization.Id,
            order_number = addedOrganization.OrderNumber,
            state_organization = addedOrganization.StateOrganization,
            is_grouper = addedOrganization.IsGrouper,
            supreor_organization = addedOrganization.SuperiorOrganization,
            short_name = addedOrganization.ShortName,
            full_name = addedOrganization.FullName,
            status = addedOrganization.Status,
        };
    }
}
