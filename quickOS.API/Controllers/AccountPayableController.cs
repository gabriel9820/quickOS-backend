using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/account-payable")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AccountPayableController : ControllerBase
{
    private readonly IAccountPayableService _accountPayableService;

    public AccountPayableController(IAccountPayableService accountPayableService)
    {
        _accountPayableService = accountPayableService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AccountPayableQueryParams queryParams)
    {
        var result = await _accountPayableService.GetAllAsync(queryParams);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("{externalId:Guid}")]
    public async Task<IActionResult> GetByExternalId(Guid externalId)
    {
        var result = await _accountPayableService.GetByExternalIdAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AccountPayableInputModel accountPayableInputModel)
    {
        var result = await _accountPayableService.CreateAsync(accountPayableInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetByExternalId), new { externalId = result.Data!.ExternalId }, result.Data);
    }

    [HttpPut("{externalId:Guid}")]
    public async Task<IActionResult> Update(Guid externalId, [FromBody] AccountPayableInputModel accountPayableInputModel)
    {
        var result = await _accountPayableService.UpdateAsync(externalId, accountPayableInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpDelete("{externalId:Guid}")]
    public async Task<IActionResult> Delete(Guid externalId)
    {
        var result = await _accountPayableService.DeleteAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return NoContent();
    }
}
