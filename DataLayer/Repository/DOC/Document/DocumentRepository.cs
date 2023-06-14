using DataLayer.Context;
using DomainLayer.Entities.DOC;

namespace DataLayer.Repository;
internal class DocumentRepository : BaseRepository<Document, int>, IDocumentRepository
{
    public DocumentRepository(ApplicationDbContext appDbContext) 
        : base(appDbContext)
    { }
}
