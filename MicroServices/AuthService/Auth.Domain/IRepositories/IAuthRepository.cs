using Auth.Domain.DTOs;
using Auth.Domain.Models;

namespace Auth.Application.IRepositories;

public interface IAuthRepository
{
    Task<string> CreateAccount(UserDto userDto);
    Task<AppUser> LoginAccount(LoginDto loginDto);
}