using AutoMapper;
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
    private readonly IMapper mapper;
    public SectorService(
        ISectorRepository sectorRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.sectorRepository = sectorRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<SectorDto> CreateSectorAsync(SectorDlDto sector)
    {
        var newSector = this.mapper
            .Map<Sector>(sector);

        var addedSector = await this.sectorRepository
            .InsertAsync(newSector);

        return this.mapper
            .Map<SectorDto>(addedSector);
    }

    public IQueryable<SectorDto> SectorsSelectListAsync()
    {
        var allSectors = this.sectorRepository
            .SelectAll()
            .Include(se => se.State);

        return allSectors
            .Select(c => this.mapper.Map<SectorDto>(c));
    }

    public async ValueTask<SectorDto> DeleteSectorAsync(int id)
    {
        var storageSector = await this.sectorRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
           .GenericValidation<Sector>(storageSector, id);

        var removedSector = await this.sectorRepository
            .DeleteAsync(storageSector);

        return this.mapper
            .Map<SectorDto>(storageSector);
    }

    public async ValueTask<SectorDto> SelectSectorByIdAsync(int id)
    {
        var storageSector = await this.sectorRepository
            .SelectByIdWithDetailsAsync(
            expression: s => s.Id == id,
            includes: new string[]
            {
                nameof(Sector.State)
            });

        return this.mapper
            .Map<SectorDto>(storageSector);
    }

    public async ValueTask<SectorDto> UpdateSectorAsync(SectorUpdateDlDto sectorUpdateDlDto)
    {
        var sector = await this.sectorRepository
            .SelectByIdAsync(sectorUpdateDlDto.Id);

        ValidationStorageObj
            .GenericValidation<Sector>(sector, sectorUpdateDlDto.Id);

        var modifySector = this.mapper
            .Map(sectorUpdateDlDto, sector);

        return this.mapper
            .Map<SectorDto>(await this.sectorRepository.UpdateAsync(modifySector));
    }
}
