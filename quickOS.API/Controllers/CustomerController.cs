using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/customer")]
[ApiController]
[Authorize]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CustomerQueryParams queryParams)
    {
        var result = await _customerService.GetAllAsync(queryParams);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("fill-autocomplete")]
    public async Task<IActionResult> FillAutocompleteAsync()
    {
        var result = await _customerService.FillAutocompleteAsync();

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("{externalId:Guid}")]
    public async Task<IActionResult> GetByExternalId(Guid externalId)
    {
        var result = await _customerService.GetByExternalIdAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("next-code")]
    [Authorize(Roles = "Admin,Attendant")]
    public async Task<IActionResult> GetNextCode()
    {
        var result = await _customerService.GetNextCode();

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Attendant")]
    public async Task<IActionResult> Create([FromBody] CustomerInputModel customerInputModel)
    {
        var result = await _customerService.CreateAsync(customerInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetByExternalId), new { externalId = result.Data!.ExternalId }, result.Data);
    }

    [HttpPut("{externalId:Guid}")]
    [Authorize(Roles = "Admin,Attendant")]
    public async Task<IActionResult> Update(Guid externalId, [FromBody] CustomerInputModel customerInputModel)
    {
        var result = await _customerService.UpdateAsync(externalId, customerInputModel);

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
        var result = await _customerService.DeleteAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return NoContent();
    }
}
