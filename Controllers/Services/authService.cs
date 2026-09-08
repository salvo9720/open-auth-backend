using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.AppDbContext;
using open_auth_backend.Database.NTT;
namespace open_auth_backend.Controllers.Services;


public class AuthService
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> ValidateCredentialsAsync(
        string username,
        string password)
    {
        UserNTT user = await _db.Users
            .FirstOrDefaultAsync(x => x.Username == username);

        if (user is null)
        {
            return false;
        }

        return BCrypt.Net.BCrypt.Verify(
            password,
            user.PasswordHash);
    }
}