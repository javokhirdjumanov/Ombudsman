namespace ServiceLayer.Services;
public interface IOrganizationService
{
    ValueTask<OrgDto> CreateAsync(OrgDlDto orgDlDto);
    IQueryable<OrgDto> SelectList();
    ValueTask<OrgDto> SelectByIdAsync(int id);
    ValueTask<OrgDto> UpdateAsync(OrgDlDtoForModify orgDlDtoForModify);
    ValueTask<OrgDto> DeleteAsync(int id);
    ValueTask<List<EmpDto>> SelectEmployeesOfOrganization();
}
