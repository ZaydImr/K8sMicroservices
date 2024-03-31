using System.ComponentModel.DataAnnotations;

namespace Auth.Domain.Contracts.Login;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
