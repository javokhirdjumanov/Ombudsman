namespace ServiceLayer.Services;
public interface IEmployeeService
{
    ValueTask<EmpDto> CreateAsync(EmpCreateDlDto empDlDto);
    IQueryable<EmpDto> SelectList();
    ValueTask<EmpDto> SelectById(int id);
    ValueTask<EmpDto> UpdateAsync(EmpUpdateDlDto empUpdateDlDto);
    ValueTask<EmpDto> DeleteAsync(int id);
}
