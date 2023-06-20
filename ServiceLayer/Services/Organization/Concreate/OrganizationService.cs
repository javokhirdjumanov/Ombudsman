using AutoMapper;
using DataLayer;
using DataLayer.Repository;
using DomainLayer.Entities;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Validations;
using System.Net.Http.Headers;

namespace ServiceLayer.Services;
public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository organizationRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IAuthServices authServices;
    public OrganizationService(
        IOrganizationRepository organizationRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthServices authServices)
    {
        this.organizationRepository = organizationRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.authServices = authServices;
    }

    public async ValueTask<OrgDto> CreateAsync(OrgDlDto orgDlDto)
    {
        var newOrg = this.mapper.Map<Organization>(orgDlDto);

        var addedOrganization = await this.organizationRepository
            .InsertAsync(newOrg);

        return this.mapper.Map<OrgDto>(addedOrganization);
    }
    public IQueryable<OrgDto> SelectList()
    {
        var organizations = this.organizationRepository
            .SelectAll()
            .Where(o => o.Id == authServices.User.OrganizationId)
            .Include(o => o.State)
            .Include(o => o.StateOrganizationIdsNavigation);

        return organizations
            .Select(o => this.mapper.Map<OrgDto>(o));
    }
    public async ValueTask<OrgDto> SelectByIdAsync(int id)
    {
        var org = await this.organizationRepository
            .SelectByIdWithDetailsAsync(
            expression: org => org.Id == id,
            includes: new string[]
            {
                nameof(Organization.StateOrganizationIdsNavigation),
                nameof(Organization.State)
            });

        var orgsad = this.unitOfWork.context.StateOrganizationTranslates
            .FirstOrDefault(o => o.OwnerId == org.Id && o.LanguageId == authServices.User.LanguageId);

        org.FullName = orgsad.TranslateText;
        org.ShortName = orgsad.TranslateText;

        return this.mapper
            .Map<OrgDto>(org);
    }
    public async ValueTask<OrgDto> UpdateAsync(OrgDlDtoForModify orgDlDtoForModify)
    {
        var storageOrg = await this.organizationRepository
            .SelectByIdAsync(orgDlDtoForModify.Id);

        ValidationStorageObj
            .GenericValidation<Organization>(storageOrg, orgDlDtoForModify.Id);

        var mapOrg = this.mapper
            .Map(orgDlDtoForModify, storageOrg);

        var modifyOrg = await this.organizationRepository
            .UpdateAsync(mapOrg);

        return this.mapper.Map<OrgDto>(modifyOrg);
    }
    public async ValueTask<OrgDto> DeleteAsync(int id)
    {
        var storageOrganization = await this.organizationRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
            .GenericValidation<Organization>(storageOrganization, id);

        var removeOrg = await this.organizationRepository
            .DeleteAsync(storageOrganization);

        return this.mapper.Map<OrgDto>(storageOrganization);
    }
}
