namespace ServiceLayer.Services;
public interface IStateProgramService
{
    ValueTask<SPDto> CreateStateProgramAsync(SPDlDto spDlDto);
    IQueryable<SPDto> GetListStateProgramAsync();
    ValueTask<SPDto> DeleteStateProgramAsync(int id);
}
