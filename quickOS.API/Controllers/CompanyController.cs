using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/company")]
[ApiController]
[Authorize]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrent()
    {
        var result = await _companyService.GetCurrentAsync();

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }
}
