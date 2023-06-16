using DataLayer;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
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
            .Include(x => x.State);
    }

    public IQueryable<PerformerType> PerformerTypesSelectList()
    {
        return
            this.unitOfWork.context.PerformerTypes
            .Include(x => x.State);
    }

    public IQueryable<StateOrganization> StateOrganizationSelectList()
    {
        return
           this.unitOfWork.context.StateOrganizations
           .Include(x => x.State);
    }

    public IQueryable<State> StatusSelectList()
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
        return this.unitOfWork.context.DocumentStatuses.Include(d => d.State);
    }

    public IQueryable<DocumentImportance> DocumentImportanceSelectList()
    {
        return this.unitOfWork.context.DocumentImportances.Include(d => d.State);
    }
}
