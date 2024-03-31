using Auth.Domain.Contracts.Login;
using Auth.Domain.DTOs;
using Auth.Domain.Models;

namespace Auth.Application.IRepositories;

public interface IAuthRepository
{
    Task<string> CreateAccount(RegisterDto userDto);
    Task<AppUser> LoginAccount(LoginRequest loginDto);
}