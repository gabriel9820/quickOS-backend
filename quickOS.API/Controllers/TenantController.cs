using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/tenant")]
[ApiController]
[Authorize]
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
}
