namespace ServiceLayer.Services;
public interface IStateProgramService
{
    ValueTask<SPDto> CreateAsync(SPDlDto dto);
    IQueryable<SPDto> SelectList();
    ValueTask<SPDto> SelectByIdAsync(int id);
    ValueTask<SPDto> UpdateAsync(SPModifyDlDto dto);
    ValueTask<SPDto> DeleteAsync(int id);
}
