using Auth.Application.IRepositories;
using Auth.Domain.DTOs;
using Auth.Domain.Exceptions;
using Auth.Domain.Models;
using Auth.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Repository;

public class AuthRepository(AuthDataContext _db, UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager) : IAuthRepository
{
    public async Task<string> CreateAccount(UserDto userDto)
    {
        if (userDto is null)
            throw new GlobalException("Model is empty");

        AppUser newUser = new AppUser()
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
            PasswordHash = userDto.Password
        };

        var createdUser = await _userManager.CreateAsync(newUser, userDto.Password);
        if (!createdUser.Succeeded)
        {
            throw new GlobalException(createdUser.Errors.First().Description);
        }

        foreach (string role in userDto.Roles)
        {
            var checkRole = await _roleManager.FindByNameAsync(role.ToUpper());
            if (checkRole is null)
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = role.ToUpper() });
            }
            await _userManager.AddToRoleAsync(newUser, role);
        }

        return "Account created";
    }

    public async Task<AppUser> LoginAccount(LoginDto loginDto)
    {
        if (loginDto is null)
            throw new GlobalException("Login container is empty");

        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user is null)
            throw new ItemNotFoundException("User not found");

        bool isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!isValidPassword)
            throw new GlobalException("Invalid email/password");

        var userRoles = await _userManager.GetRolesAsync(user);
        user.Roles = _db.Roles.Where(role => userRoles.Contains(role.Name!)).ToList();
        
        return user;
    }
}
