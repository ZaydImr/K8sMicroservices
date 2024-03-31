using Auth.Application.IRepositories;
using Auth.Contracts.Common;
using Auth.Contracts.Login;
using Auth.Domain.DTOs;
using Auth.Domain.IServices;
using Auth.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Application.Services;

public class AuthService(IAuthRepository _authRepository, IConfiguration _config) : IAuthService
{
    public async Task<AppResponse> CreateAccount(UserDto userDto)
    {
        return new AppResponse(await _authRepository.CreateAccount(userDto));
    }

    public async Task<LoginResponse> LoginAccount(LoginDto loginDto)
    {
        var user = await _authRepository.LoginAccount(loginDto);
        return new LoginResponse(GenerateToken(user));
    }

    private string GenerateToken(AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, user.Roles.First()!.Name!)
            };

        var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(Double.Parse(_config["Jwt:Expires"]!)),
                signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
