using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/tenant")]
[ApiController]
[Authorize(Roles = "Admin")]
public class TenantController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TenantController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrent()
    {
        var result = await _tenantService.GetCurrentAsync();

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TenantInputModel inputModel)
    {
        var result = await _tenantService.UpdateAsync(inputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }
}
