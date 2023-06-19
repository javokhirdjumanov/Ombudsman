using AutoMapper;
using DataLayer;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services;
public class ManualService : IManualService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ManualService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public IQueryable<DocStatusDto> DocumentStatusSelectList()
    {
        var docStatuses = this.unitOfWork.context.DocumentStatuses
            .Include(d => d.Status);

        return docStatuses
            .Select(x => this.mapper
            .Map<DocStatusDto>(x));
    }
    public IQueryable<InitiativeTypeDto> InitiativeTypesSelectList()
    {
        var inits = this.unitOfWork.context.InitiativeTypes;

        return inits
            .Select(x => this.mapper
            .Map<InitiativeTypeDto>(x));
    }
    public IQueryable<NormativeDocTypeDto> NormativeDocumentTypesSelectList()
    {
        var normativeDocTypes = this.unitOfWork.context.NormativeDocumentTypes
            .Include(x => x.State);

        return normativeDocTypes
            .Select(x => this.mapper
            .Map<NormativeDocTypeDto>(x));
    }
    public IQueryable<PerformerTypeDto> PerformerTypesSelectList()
    {
        var performerTypes = this.unitOfWork.context.PerformerTypes
            .Include(x => x.State);

        return performerTypes.Select(x => this.mapper.Map<PerformerTypeDto>(x));
    }
    public IQueryable<StateDto> StateSelectList()
    {
        return this.unitOfWork.context.Statuses
            .Select(x => this.mapper.Map<StateDto>(x));
    }
    public IQueryable<StateOrganizationDto> StateOrganizationSelectList()
    {
        return
           this.unitOfWork.context.StateOrganizations
           .Include(x => x.State)
           .Select(x => this.mapper.Map<StateOrganizationDto>(x));
    }
    public IQueryable<DocumentImportanceDto> DocumentImportanceSelectList()
    {
        return
            this.unitOfWork.context.DocumentImportances
            .Include(d => d.State)
            .Select(x => this.mapper.Map<DocumentImportanceDto>(x));
    }
    public IQueryable<UserRoleDto> UserRoleSelectList()
    {
        return
            this.unitOfWork.context.UserRoles
            .Select(x => this.mapper.Map<UserRoleDto>(x));
    }

    public IQueryable<LanguageDto> LanguageSelectList()
    {
        return this.unitOfWork.context.Languages
            .Select(x => this.mapper.Map<LanguageDto>(x));
    }
}
