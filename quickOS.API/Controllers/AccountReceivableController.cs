using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/account-receivable")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AccountReceivableController : ControllerBase
{
    private readonly IAccountReceivableService _accountReceivableService;

    public AccountReceivableController(IAccountReceivableService accountReceivableService)
    {
        _accountReceivableService = accountReceivableService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AccountReceivableQueryParams queryParams)
    {
        var result = await _accountReceivableService.GetAllAsync(queryParams);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("{externalId:Guid}")]
    public async Task<IActionResult> GetByExternalId(Guid externalId)
    {
        var result = await _accountReceivableService.GetByExternalIdAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AccountReceivableInputModel accountReceivableInputModel)
    {
        var result = await _accountReceivableService.CreateAsync(accountReceivableInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetByExternalId), new { externalId = result.Data!.ExternalId }, result.Data);
    }

    [HttpPut("{externalId:Guid}")]
    public async Task<IActionResult> Update(Guid externalId, [FromBody] AccountReceivableInputModel accountReceivableInputModel)
    {
        var result = await _accountReceivableService.UpdateAsync(externalId, accountReceivableInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpDelete("{externalId:Guid}")]
    public async Task<IActionResult> Delete(Guid externalId)
    {
        var result = await _accountReceivableService.DeleteAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return NoContent();
    }
}
