namespace ServiceLayer.Services;
public interface ISectorService
{
    ValueTask<SectorDto> CreateSectorAsync(SectorDlDto sector);
    IQueryable<SectorDto> SectorsSelectListAsync();
    ValueTask<SectorDto> DeleteSectorAsync(int id);
}
