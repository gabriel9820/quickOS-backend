using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/service-order")]
[ApiController]
[Authorize]
public class ServiceOrderController : ControllerBase
{
    private readonly IServiceOrderService _serviceOrderService;

    public ServiceOrderController(IServiceOrderService serviceOrderService)
    {
        _serviceOrderService = serviceOrderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ServiceOrderQueryParams queryParams)
    {
        var result = await _serviceOrderService.GetAllAsync(queryParams);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("{externalId:Guid}")]
    public async Task<IActionResult> GetByExternalId(Guid externalId)
    {
        var result = await _serviceOrderService.GetByExternalIdAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("next-number")]
    [Authorize(Roles = "Admin,Attendant")]
    public async Task<IActionResult> GetNextNumber()
    {
        var result = await _serviceOrderService.GetNextNumber();

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Attendant")]
    public async Task<IActionResult> Create([FromBody] ServiceOrderInputModel serviceOrderInputModel)
    {
        var result = await _serviceOrderService.CreateAsync(serviceOrderInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetByExternalId), new { externalId = result.Data!.ExternalId }, result.Data);
    }

    [HttpPut("{externalId:Guid}")]
    public async Task<IActionResult> Update(Guid externalId, [FromBody] ServiceOrderInputModel serviceOrderInputModel)
    {
        var result = await _serviceOrderService.UpdateAsync(externalId, serviceOrderInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPatch("{externalId:Guid}")]
    [Authorize(Roles = "Admin,Attendant")]
    public async Task<IActionResult> Invoice(Guid externalId, [FromBody] ServiceOrderInvoiceInputModel inputModel)
    {
        var result = await _serviceOrderService.InvoiceAsync(externalId, inputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return NoContent();
    }

    [HttpDelete("{externalId:Guid}")]
    [Authorize(Roles = "Admin,Attendant")]
    public async Task<IActionResult> Delete(Guid externalId)
    {
        var result = await _serviceOrderService.DeleteAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return NoContent();
    }
}
