using DataLayer;
using DomainLayer.Entities.ENUM;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services;
public class ManualService : IManualService
{
    private readonly IUnitOfWork unitOfWork;
    public ManualService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public IQueryable<NormativeDocumentType> NormativeDocumentTypesSelectList()
    {
        return
            this.unitOfWork.context.NormativeDocumentTypes
            .Include(x => x.Status);
    }

    public IQueryable<PerformerType> PerformerTypesSelectList()
    {
        return
            this.unitOfWork.context.PerformerTypes
            .Include(x => x.Status);
    }

    public IQueryable<StateOrganization> StateOrganizationSelectList()
    {
        return
           this.unitOfWork.context.StateOrganizations
           .Include(x => x.Status);
    }

    public IQueryable<Status> StatusSelectList()
    {
        return
            this.unitOfWork.context.Statuses;
    }

    public IQueryable<InitiativeType> InitiativeTypesSelectList()
    {
        return this.unitOfWork.context.InitiativeTypes;
    }

    public IQueryable<DocumentStatus> DocumentStatusSelectList()
    {
        return this.unitOfWork.context.DocumentStatuses.Include(d => d.Status);
    }
}
