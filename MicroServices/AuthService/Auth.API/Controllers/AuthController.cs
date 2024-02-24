using Auth.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Service.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    [HttpGet("login")]
    public string Login()
    {
        return "Login here.";
    }
}
