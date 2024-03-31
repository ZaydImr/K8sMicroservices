using Auth.Domain.DTOs;
using Auth.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[Route("api")]
[ApiController]
public class AuthController(IAuthService _authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
        var response = await _authService.CreateAccount(userDto);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var response = await _authService.LoginAccount(loginDto);
        return Ok(response);
    }
}
