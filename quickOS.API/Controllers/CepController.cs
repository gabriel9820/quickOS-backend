using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/cep")]
[ApiController]
[Authorize]
public class CepController : ControllerBase
{
    private readonly ICepService _cepService;

    public CepController(ICepService cepService)
    {
        _cepService = cepService;
    }

    [HttpGet("{cep}")]
    public async Task<IActionResult> GetAddressByCep(string cep)
    {
        var result = await _cepService.GetAddressByCepAsync(cep);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }
}
