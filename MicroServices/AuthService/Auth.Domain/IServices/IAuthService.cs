using Auth.Contracts.Common;
using Auth.Contracts.Login;
using Auth.Domain.DTOs;

namespace Auth.Domain.IServices;

public interface IAuthService
{
    Task<AppResponse> CreateAccount(UserDto userDto);
    Task<LoginResponse> LoginAccount(LoginDto loginDto);
}