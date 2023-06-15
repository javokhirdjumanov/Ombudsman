using DataLayer;
using DataLayer.Repository;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Extantions;
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
        sector.status_id.IsDefault();

        var storageStatus = await this.unitOfWork.context.Statuses
            .FirstOrDefaultAsync(x => x.Id == sector.status_id);

        ValidationStorageObj
            .GenericValidation<Status>(storageStatus, sector.status_id);

        var newSector = new Sectors
        {
            SectorNumber = sector.sector_number,
            Status = storageStatus,
            OrderNumber = sector.order_number,
            ShortName = sector.short_name,
            FullName = sector.full_name
        };

        var addedSector = await this.sectorRepository
            .InsertAsync(newSector);

        return new SectorDto(
                addedSector.Id,
                addedSector.SectorNumber,
                new Status{Id = addedSector.StatusId,
                Name = addedSector.Status.Name},
                addedSector.OrderNumber,
                addedSector.ShortName,
                addedSector.FullName);
    }

    public IQueryable<SectorDto> SectorsSelectListAsync()
    {
        var allSectors = this.sectorRepository
            .SelectAll()
            .Include(se => se.Status).Where(se => se.StatusId != 3);

        return allSectors.Select(x => new SectorDto(x.Id,
                x.SectorNumber,
                new Status { Id = x.StatusId, Name = x.Status.Name},
                x.OrderNumber,
                x.ShortName,
                x.FullName));
    }

    public async ValueTask<SectorDto> DeleteSectorAsync(int id)
    {
        id.IsDefault();

        var storageSector = await this.sectorRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
           .GenericValidation<Sectors>(storageSector, id);

        var deleteStatusObj = this.unitOfWork.context.Statuses
            .FirstOrDefault(x => x.Id == 3);

        storageSector.Status = deleteStatusObj;

        var updateSector = await this.sectorRepository
            .UpdateAsync(storageSector);

        return new SectorDto(
           updateSector.Id,
           updateSector.OrderNumber,
           new Status { Id = updateSector.StatusId, Name = updateSector.Status.Name },
           updateSector.OrderNumber,
           updateSector.ShortName,
           updateSector.FullName);
    }
}
