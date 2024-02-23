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

    [HttpPost("login")]
    public async Task Login([FromBody] LoginInputModel loginInputModel)
    {
        await _authService.LoginAsync(loginInputModel);
    }

    [HttpPost("register")]
    public async Task Register([FromBody] RegisterInputModel registerInputModel)
    {
        await _authService.RegisterAsync(registerInputModel);
    }
}
