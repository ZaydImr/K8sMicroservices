using Auth.Domain.DTOs;

namespace Auth.Domain.Contracts.RefreshToken;

public record class RefreshTokenRequest(string Token, UserDto User);