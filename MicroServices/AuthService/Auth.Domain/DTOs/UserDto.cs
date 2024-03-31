using System.ComponentModel.DataAnnotations;

namespace Auth.Domain.DTOs;

public class UserDto
{
    public string? Id { get; set; } = string.Empty;

    [Required]
    public required string UserName { get; set; }

    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }

    public required List<string> Roles { get; set; }
}
