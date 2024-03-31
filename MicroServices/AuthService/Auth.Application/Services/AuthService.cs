using Auth.Application.IRepositories;
using Auth.Application.Mappers;
using Auth.Contracts.Common;
using Auth.Contracts.Login;
using Auth.Domain.Contracts.Login;
using Auth.Domain.Contracts.RefreshToken;
using Auth.Domain.DTOs;
using Auth.Domain.Exceptions;
using Auth.Domain.IServices;
using Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Application.Services;

public class AuthService(IAuthRepository _authRepository, IConfiguration _config, UserMapper _mapper) : IAuthService
{
    public async Task<AppResponse> CreateAccount(RegisterDto registerDto)
    {
        return new AppResponse(await _authRepository.CreateAccount(registerDto));
    }

    public async Task<LoginResponse> LoginAccount(LoginRequest loginDto)
    {
        var user = await _authRepository.LoginAccount(loginDto);
        string token = GenerateToken(user);

        return new LoginResponse(token, _mapper.ToDto(user));
    }

    public async Task<LoginResponse> RefreshToken(RefreshTokenRequest request)
    {
        AppUser user = _mapper.ToEntity(request.User);
        string token = await GenerateRefreshToken(request.Token, user);

        return new LoginResponse(token, request.User);
    }

    #region Tokens 
    private string GenerateToken(AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };

        foreach(IdentityRole role in user.Roles)
        {
            userClaims.Add(new Claim(ClaimTypes.Role, role.Name!));
        }

        var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: null,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(Double.Parse(_config["Jwt:Expires"]!)),
                signingCredentials: credentials
            );

        token.Payload["aud"] = GetAudiences();

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<string> GenerateRefreshToken(string token, AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var tokenHandler = new JwtSecurityTokenHandler();

        

        var results = await tokenHandler.ValidateTokenAsync(
            token: token, 
            new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudiences = GetAudiences(),
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateLifetime = true
            }
        );

        if (!results.IsValid)
            throw new GlobalException("Session ended, login again please.");

        return GenerateToken(user);
    }

    private List<string> GetAudiences()
    {
        var Audiences = new List<string>();
        var AudiencesSection = _config.GetSection("Jwt:Audiences");

        foreach (var child in AudiencesSection.GetChildren())
        {
            Audiences.Add(child.Value!);
        }

        return Audiences;
    }
    #endregion
}
