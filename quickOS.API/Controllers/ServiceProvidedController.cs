using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/service-provided")]
[ApiController]
[Authorize]
public class ServiceProvidedController : ControllerBase
{
    private readonly IServiceProvidedService _serviceProvidedService;

    public ServiceProvidedController(IServiceProvidedService serviceProvidedService)
    {
        _serviceProvidedService = serviceProvidedService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ServiceProvidedQueryParams queryParams)
    {
        var result = await _serviceProvidedService.GetAllAsync(queryParams);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("{externalId:Guid}")]
    public async Task<IActionResult> GetByExternalId(Guid externalId)
    {
        var result = await _serviceProvidedService.GetByExternalIdAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] ServiceProvidedInputModel serviceInputModel)
    {
        var result = await _serviceProvidedService.CreateAsync(serviceInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetByExternalId), new { externalId = result.Data!.ExternalId }, result.Data);
    }

    [HttpPut("{externalId:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid externalId, [FromBody] ServiceProvidedInputModel serviceInputModel)
    {
        var result = await _serviceProvidedService.UpdateAsync(externalId, serviceInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpDelete("{externalId:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid externalId)
    {
        var result = await _serviceProvidedService.DeleteAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return NoContent();
    }
}
