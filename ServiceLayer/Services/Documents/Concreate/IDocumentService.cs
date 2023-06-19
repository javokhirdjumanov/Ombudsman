using DataLayer.Context;
using ServiceLayer.Services.Documents;

namespace ServiceLayer.Services;
public interface IDocumentService
{
    ValueTask<int> CreateAsync(DocCreateDlDto docCreateDlDto);
    IQueryable<DocumentDto> SelectListAsync();
    ValueTask<DocumentDto> SelectByIdAsync(int id);
    ValueTask<DocumentDto> UpdateAsync(DocModDlDto docModDlDto);
    ValueTask<int> DeleteAsync(int id);
    ValueTask<List<VizaHolderDto>> VisaViewersOfDocument(int documentId);
    IQueryable<function_model> SelectDocumentByOrganization(
        int organizationId, DateOnly from_date, DateOnly to_date);
}
