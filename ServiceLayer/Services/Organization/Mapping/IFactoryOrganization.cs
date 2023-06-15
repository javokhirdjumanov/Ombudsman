using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;

namespace ServiceLayer.Services;
public interface IFactoryOrganization
{
    OrgDto MapToOrganizationDto(Organization organization);
    Organization MapToOrganization(OrgDlDto dto, StateOrganization stateOrganization, Organization? organization, Status status);
    void MapToOrganization(Organization organization, OrgDlDtoForModify orgDlDtoForModify);
}
