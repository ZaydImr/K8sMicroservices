using Auth.Application.IRepositories;
using Auth.Infrastructure.Data;

namespace Auth.Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private AuthDataContext _db;

    public AuthRepository(AuthDataContext db)
    {
        _db = db;
    }
}
