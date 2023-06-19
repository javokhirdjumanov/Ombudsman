namespace ServiceLayer.Services;
public interface IStateProgramService
{
    ValueTask<SPDto> CreateStateProgramAsync(SPDlDto dto);
    IQueryable<SPDto> StateProgramSelectList();
    ValueTask<SPDto> SelectByIdAsync(int id);
    ValueTask<SPDto> UpdateAsync(SPModifyDlDto dto);
    ValueTask<SPDto> DeleteStateProgramAsync(int id);
}
