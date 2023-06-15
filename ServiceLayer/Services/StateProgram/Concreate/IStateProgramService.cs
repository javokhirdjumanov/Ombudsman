namespace ServiceLayer.Services;
public interface IStateProgramService
{
    ValueTask<SPDto> CreateStateProgramAsync(SPDlDto spDlDto);
    IQueryable<SPDto> StateProgramSelectListAsync();
    ValueTask<SPDto> DeleteStateProgramAsync(int id);
}
