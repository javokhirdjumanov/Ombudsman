using DataLayer.Context;
using DomainLayer.Entities.DOC;

namespace DataLayer.Repository;
internal class DocumentRepository : BaseRepository<Document, int>, IDocumentRepository
{
    private readonly ApplicationDbContext appDbContext;
    public DocumentRepository(ApplicationDbContext appDbContext)
        : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public IQueryable<function_model> SelectDocumentByOrganization(
        int organizationId,
        DateOnly from_date,
        DateOnly to_date)
    {
        return this.appDbContext
            .SelectDocumentByOrganization(organizationId, from_date, to_date);
    }
}
