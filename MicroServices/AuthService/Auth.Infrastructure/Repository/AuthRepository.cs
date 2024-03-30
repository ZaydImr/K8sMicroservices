using Auth.Application.IRepositories;
using Auth.Domain.Models;
using Auth.Infrastructure.Data;

namespace Auth.Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private AuthDataContext _db;

    public AuthRepository(AuthDataContext db)
    {
        _db = db;
    }

    public List<AppUser> GetUsers()
    {
        return _db.Users.ToList();
    }
}
