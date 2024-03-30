using Auth.Application.IRepositories;
using Auth.Domain.IServices;

namespace Auth.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository authRepository;
}
