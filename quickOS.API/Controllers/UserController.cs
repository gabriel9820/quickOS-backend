using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/user")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll([FromQuery] UserQueryParams queryParams)
    {
        var result = await _userService.GetAllAsync(queryParams);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpGet("{externalId:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByExternalId(Guid externalId)
    {
        var result = await _userService.GetByExternalIdAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Ok(result.Data);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] UserInputModel userInputModel)
    {
        var result = await _userService.CreateAsync(userInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetByExternalId), new { externalId = result.Data!.ExternalId }, result.Data);
    }

    [HttpPut("{externalId:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid externalId, [FromBody] UserInputModel userInputModel)
    {
        var result = await _userService.UpdateAsync(externalId, userInputModel);

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
        var result = await _userService.DeleteAsync(externalId);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return NoContent();
    }
}
