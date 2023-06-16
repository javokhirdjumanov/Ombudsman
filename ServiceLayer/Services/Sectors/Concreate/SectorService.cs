using DataLayer;
using DataLayer.Repository;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public class SectorService : ISectorService
{
    private readonly ISectorRepository sectorRepository;
    private readonly IUnitOfWork unitOfWork;
    public SectorService(ISectorRepository sectorRepository, IUnitOfWork unitOfWork)
    {
        this.sectorRepository = sectorRepository;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<SectorDto> CreateSectorAsync(SectorDlDto sector)
    {
        var storageStatus = await this.unitOfWork.context.Statuses
            .FirstOrDefaultAsync(x => x.Id == sector.status_id);

        ValidationStorageObj
            .GenericValidation<State>(storageStatus, sector.status_id);

        var newSector = new Sectors
        {
            SectorNumber = sector.sector_number,
            State = storageStatus,
            OrderNumber = sector.order_number,
            ShortName = sector.short_name,
            FullName = sector.full_name
        };

        var addedSector = await this.sectorRepository
            .InsertAsync(newSector);

        return new SectorDto(
                addedSector.Id,
                addedSector.SectorNumber,
                new State{Id = addedSector.StateId,
                Name = addedSector.State.Name},
                addedSector.OrderNumber,
                addedSector.ShortName,
                addedSector.FullName);
    }

    public IQueryable<SectorDto> SectorsSelectListAsync()
    {
        var allSectors = this.sectorRepository
            .SelectAll()
            .Include(se => se.State).Where(se => se.StateId != 3);

        return allSectors.Select(x => new SectorDto(x.Id,
                x.SectorNumber,
                new State { Id = x.StateId, Name = x.State.Name},
                x.OrderNumber,
                x.ShortName,
                x.FullName));
    }

    public async ValueTask<SectorDto> DeleteSectorAsync(int id)
    {
        var storageSector = await this.sectorRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
           .GenericValidation<Sectors>(storageSector, id);

        var deleteStatusObj = this.unitOfWork.context.Statuses
            .FirstOrDefault(x => x.Id == 3);

        storageSector.State = deleteStatusObj;

        var updateSector = await this.sectorRepository
            .UpdateAsync(storageSector);

        return new SectorDto(
           updateSector.Id,
           updateSector.OrderNumber,
           new State { Id = updateSector.StateId, Name = updateSector.State.Name },
           updateSector.OrderNumber,
           updateSector.ShortName,
           updateSector.FullName);
    }
}
