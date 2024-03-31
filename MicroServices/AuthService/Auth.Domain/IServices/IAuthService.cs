using Auth.Contracts.Common;
using Auth.Contracts.Login;
using Auth.Domain.Contracts.Login;
using Auth.Domain.Contracts.RefreshToken;
using Auth.Domain.DTOs;

namespace Auth.Domain.IServices;

public interface IAuthService
{
    Task<AppResponse> CreateAccount(RegisterDto userDto);
    Task<LoginResponse> LoginAccount(LoginRequest loginDto);
    Task<LoginResponse> RefreshToken(RefreshTokenRequest request);
}