using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;

namespace ServiceLayer.Services;
public interface IManualService
{
    IQueryable<NormativeDocumentType> NormativeDocumentTypesSelectList();
    IQueryable<PerformerType> PerformerTypesSelectList();
    IQueryable<StateOrganization> StateOrganizationSelectList();
    IQueryable<State> StatusSelectList();
    IQueryable<InitiativeType> InitiativeTypesSelectList();
    IQueryable<DocumentStatus> DocumentStatusSelectList();
    IQueryable<DocumentImportance> DocumentImportanceSelectList();
}
