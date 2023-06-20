using AutoMapper;
using DataLayer;
using DataLayer.Repository;
using DomainLayer.Constants;
using DomainLayer.Entities;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public partial class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAuthServices authServices;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public EmployeeService(
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthServices authServices)
    {
        this.employeeRepository = employeeRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.authServices = authServices;
    }
    public async ValueTask<EmpDto> CreateAsync(EmpCreateDlDto empDlDto)
    {
        ValidationIfPersonHisOrganization(empDlDto.organizationId);

        var employee = mapper
            .Map<Employee>(empDlDto);

        var addedEmployee = await this.employeeRepository
            .InsertAsync(employee);

        return this.mapper
            .Map<EmpDto>(addedEmployee);
    }
    public async ValueTask<EmpDto> SelectById(int id)
    {
        var storageEmp = await this.employeeRepository.SelectByIdWithDetailsAsync(
        expression: e => e.Id == id && e.Organization.StateId != StateIds.DELETE,
        includes: new string[]
        {
            nameof(Employee.Organization),
            $"{nameof(Employee.Organization)}.{nameof(Organization.State)}",
            $"{nameof(Employee.Organization)}.{nameof(Organization.StateOrganizationIdsNavigation)}"
        });

        ValidationStorageObj
            .GenericValidation<Employee>(storageEmp, id);

        ValidationIfPersonHisOrganization(storageEmp.OrganizationId);

        return this.mapper
            .Map<EmpDto>(storageEmp);
    }
    public IQueryable<EmpDto> SelectList()
    {
        var employees = this.employeeRepository
            .SelectAll()
            .Include(e => e.Organization)
            .ThenInclude(o => o.State)
            .Where(e => e.OrganizationId == this.authServices.User.OrganizationId);

        return employees
            .Select(emp => this.mapper
            .Map<EmpDto>(emp));
    }
    public async ValueTask<EmpDto> UpdateAsync(EmpUpdateDlDto empModifyDlDto)
    {
        var storageEmp = await this.employeeRepository
            .SelectByIdAsync(empModifyDlDto.id);

        ValidationStorageObj
            .GenericValidation<Employee>(storageEmp, empModifyDlDto.id);

        var emp = this.mapper
            .Map(empModifyDlDto, storageEmp);

        var modifyEmp = await this.employeeRepository
            .UpdateAsync(emp);

        return this.mapper
            .Map<EmpDto>(modifyEmp);
    }
    public async ValueTask<EmpDto> DeleteAsync(int id)
    {
        var badEmployee = await this.employeeRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
            .GenericValidation<Employee>(badEmployee, id);

        ValidationIfPersonHisOrganization(badEmployee.OrganizationId);

        badEmployee = await this.employeeRepository
            .DeleteAsync(badEmployee);

        return this.mapper
            .Map<EmpDto>(badEmployee);
    }
}
