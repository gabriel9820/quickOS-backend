using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/unit-of-measurement")]
[ApiController]
[Authorize]
public class UnitOfMeasurementController : ControllerBase
{
    private readonly IUnitOfMeasurementService _unitOfMeasurementService;

    public UnitOfMeasurementController(IUnitOfMeasurementService unitOfMeasurementService)
    {
        _unitOfMeasurementService = unitOfMeasurementService;
    }

    [HttpGet("fill-autocomplete")]
    public async Task<IActionResult> FillAutocomplete()
    {
        var result = await _unitOfMeasurementService.FillAutocompleteAsync();

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }
}
