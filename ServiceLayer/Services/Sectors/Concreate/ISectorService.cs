namespace ServiceLayer.Services;
public interface ISectorService
{
    ValueTask<SectorDto> CreateSectorAsync(SectorDlDto sector);
    IQueryable<SectorDto> SectorsSelectListAsync();
    ValueTask<SectorDto> SelectSectorByIdAsync(int id);
    ValueTask<SectorDto> DeleteSectorAsync(int id);
    ValueTask<SectorDto> UpdateSectorAsync(SectorUpdateDlDto sectorUpdateDlDto);
}
