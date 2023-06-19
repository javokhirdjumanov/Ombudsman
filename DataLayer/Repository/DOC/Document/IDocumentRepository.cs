using DataLayer.Context;
using DomainLayer.Entities.DOC;

namespace DataLayer.Repository;
public interface IDocumentRepository : IBaseRepository<Document, int>
{
    IQueryable<function_model> SelectDocumentByOrganization(
        int organizationId,
        DateOnly from_date,
        DateOnly to_date);
}
