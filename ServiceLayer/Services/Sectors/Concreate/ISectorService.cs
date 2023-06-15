namespace ServiceLayer.Services;
public interface ISectorService
{
    ValueTask<SectorDto> CreateSectorAsync(SectorDlDto sector);
    IQueryable<SectorDto> GetAllSectorsAsync();
    ValueTask<SectorDto> DeleteSectorAsync(int id);
}
