using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;

namespace ServiceLayer.Services;
public interface IManualService
{
    IQueryable<NormativeDocTypeDto> NormativeDocumentTypesSelectList();
    IQueryable<PerformerTypeDto> PerformerTypesSelectList();
    IQueryable<StateOrganizationDto> StateOrganizationSelectList();
    IQueryable<StateDto> StateSelectList();
    IQueryable<InitiativeTypeDto> InitiativeTypesSelectList();
    IQueryable<DocStatusDto> DocumentStatusSelectList();
    IQueryable<DocumentImportanceDto> DocumentImportanceSelectList();
    IQueryable<UserRoleDto> UserRoleSelectList();
    IQueryable<LanguageDto> LanguageSelectList();
}
