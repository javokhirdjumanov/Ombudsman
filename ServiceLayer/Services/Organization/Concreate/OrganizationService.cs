using DataLayer;
using DataLayer.Repository;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository organizationRepository;
    private readonly IFactoryOrganization factoryOrganization;
    private readonly IUnitOfWork unitOfWork;
    public OrganizationService(
        IOrganizationRepository organizationRepository,
        IUnitOfWork unitOfWork,
        IFactoryOrganization factoryOrganization)
    {
        this.organizationRepository = organizationRepository;
        this.unitOfWork = unitOfWork;
        this.factoryOrganization = factoryOrganization;
    }

    public async ValueTask<OrgDto> CreateAsync(OrgDlDto orgDlDto)
    {
        StateOrganization? stateOrg = await this.unitOfWork.context.StateOrganizations
            .FirstOrDefaultAsync(c => c.Id == orgDlDto.state_organization_id);

        ValidationStorageObj
            .GenericValidation<StateOrganization>(stateOrg, orgDlDto.state_organization_id);

        Organization? child_organization = await this.unitOfWork.context.Organizations
            .FirstOrDefaultAsync(c => c.Id == orgDlDto.organization_id);

        State? status = await this.unitOfWork.context.Statuses
            .FirstOrDefaultAsync(s => s.Id ==  orgDlDto.status_id);

        ValidationStorageObj
            .GenericValidation<State>(status, orgDlDto.state_organization_id);

        var newOrg = this.factoryOrganization
            .MapToOrganization(orgDlDto, stateOrg, child_organization, status);

        var addedOrganization = await this.organizationRepository
            .InsertAsync(newOrg);

        return this.factoryOrganization
            .MapToOrganizationDto(addedOrganization);
    }
    public async ValueTask<OrgDto> SelectByIdAsync(int id)
    {
        var organization = await this.organizationRepository
            .SelectByIdWithDetailsAsync(
            expression: org => org.Id == id && org.StateId != 3,
            includes: new string[]
            { 
                nameof(Organization.State),
                nameof(Organization.StateOrganization)
            });

        ValidationStorageObj
            .GenericValidation<Organization>(organization, id);

        return this.factoryOrganization
            .MapToOrganizationDto(organization);
    }
    public IQueryable<OrgDto> SelectList()
    {
        var organizations = this.organizationRepository
            .SelectAll()
            .Where(x => x.StateId != 3);

        return organizations
            .Select(org => this.factoryOrganization
            .MapToOrganizationDto(org));
    }
    public async ValueTask<OrgDto> DeleteAsync(int id)
    {
        var removeOrg = await this.organizationRepository
            .SelectByIdAsync(id);
        
        ValidationStorageObj
            .GenericValidation<Organization>(removeOrg, id);

        removeOrg.State = this.unitOfWork.context.Statuses
            .FirstOrDefaultAsync(x => x.Id == 3).Result;

        var updateOrg = await this.organizationRepository
            .UpdateAsync(removeOrg);

        return this.factoryOrganization
            .MapToOrganizationDto(updateOrg);
    }
    public async ValueTask<OrgDto> UpdateAsync(OrgDlDtoForModify orgDlDtoForModify)
    {
        var storageOrganization = await this.organizationRepository
            .SelectByIdAsync(orgDlDtoForModify.Id);

        this.factoryOrganization
            .MapToOrganization(storageOrganization, orgDlDtoForModify);

        var updateOrg = await this.organizationRepository
            .UpdateAsync(storageOrganization);

        return this.factoryOrganization.MapToOrganizationDto(updateOrg);
    }
}
