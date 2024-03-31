using Auth.Domain.Contracts.Login;
using Auth.Domain.Contracts.RefreshToken;
using Auth.Domain.DTOs;
using Auth.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class AuthController(IAuthService _authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var response = await _authService.CreateAccount(registerDto);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginDto)
    {
        var response = await _authService.LoginAccount(loginDto);
        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Login(RefreshTokenRequest request)
    {
        var response = await _authService.RefreshToken(request);
        return Ok(response);
    }
}