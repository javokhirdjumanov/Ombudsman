using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Ombudsman.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService organizationService;
    public OrganizationController(IOrganizationService organizationService)
    {
        this.organizationService = organizationService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<OrgDto>> CreateAsync(OrgDlDto orgDlDto)
    {
        var newOrganization = await this.organizationService.CreateAsync(orgDlDto);

        return Created("", newOrganization);
    }

    [HttpGet]
    public IActionResult SelectList()
    {
        var organizations = this.organizationService.SelectList();

        return Ok(organizations);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<ActionResult<OrgDto>> SelectByIdAsync(int id)
    {
        var organization = await this.organizationService.SelectByIdAsync(id);

        return Ok(organization);
    }

    [HttpPut]
    public async ValueTask<ActionResult<OrgDto>> UpdateAsync(OrgDlDtoForModify orgDlDtoForModify)
    {
        var updateOrg = await this.organizationService.UpdateAsync(orgDlDtoForModify);

        return Ok(updateOrg);
    }

    [HttpDelete("{id:int}")]
    public async ValueTask<ActionResult<OrgDto>> DeleteAsync(int id)
    {
        var removeOrg = await this.organizationService.DeleteAsync(id);

        return Ok(removeOrg);
    }
}
