using DomainLayer.Entities.ENUM;

namespace ServiceLayer.Services;
public interface IManualService
{
    IQueryable<NormativeDocumentType> NormativeDocumentTypesSelectList();
    IQueryable<PerformerType> PerformerTypesSelectList();
    IQueryable<StateOrganization> StateOrganizationSelectList();
    IQueryable<Status> StatusSelectList();
    IQueryable<InitiativeType> InitiativeTypesSelectList();
    IQueryable<DocumentStatus> DocumentStatusSelectList();
}
