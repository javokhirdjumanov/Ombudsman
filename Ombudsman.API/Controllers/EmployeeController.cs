using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using ServiceLayer.Servicesl;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<EmpDto>> CreateAsync(EmpCreateDlDto empDlDto)
    {
        var employee = await this._employeeService
            .CreateAsync(empDlDto);

        return Created("", employee);
    }
    [HttpGet]
    public IActionResult SelectList()
    {
        var employees = this._employeeService
            .SelectList();

        return Ok(employees);
    }
    [HttpGet("{id:int}")]
    public async ValueTask<ActionResult<EmpDto>> SelectById(int id)
    {
        var employee = await this._employeeService
            .SelectById(id);

        return Ok(employee);
    }
    [HttpPut]
    public async ValueTask<ActionResult<EmpDto>> UpdateAsync(EmpUpdateDlDto empUpdateDlDto)
    {
        var employee = await this._employeeService
            .UpdateAsync(empUpdateDlDto);
        
        return Ok(employee);
    }
    [HttpDelete]
    public async ValueTask<ActionResult<EmpDto>> DeleteAsync(int id)
    {
        var badEmployee = await this._employeeService
            .DeleteAsync(id);

        return Ok(badEmployee);
    }
}
