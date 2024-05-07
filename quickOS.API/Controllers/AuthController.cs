using Microsoft.AspNetCore.Mvc;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword()
    {
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginInputModel loginInputModel)
    {
        var result = await _authService.LoginAsync(loginInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        SetTokensInCookies(result.Data!.AccessToken, result.Data!.RefreshToken);

        return Ok(new { result.Data!.User, result.Data!.Tenant });
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var result = await _authService.RefreshTokenAsync();

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        SetTokensInCookies(result.Data!.AccessToken, result.Data!.RefreshToken);

        return NoContent();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterInputModel registerInputModel)
    {
        var result = await _authService.RegisterAsync(registerInputModel);

        if (!result.Success)
        {
            return StatusCode(result.ErrorCode, result.ErrorMessage);
        }

        return Created("", result.Data);
    }

    private void SetTokensInCookies(string accessToken, Guid refreshToken)
    {
        Response.Cookies.Append("X-Access-Token", accessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
        Response.Cookies.Append("X-Refresh-Token", refreshToken.ToString(), new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
    }
}
