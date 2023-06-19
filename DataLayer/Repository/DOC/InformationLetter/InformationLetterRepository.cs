using DataLayer.Context;
using DomainLayer.Entities.DOC;

namespace DataLayer.Repository;
public class InformationLetterRepository : BaseRepository<InformationLetter, int>, IInformationLetterRepository
{
    public InformationLetterRepository(ApplicationDbContext appDbContext) 
        : base(appDbContext)
    {
    }
}
