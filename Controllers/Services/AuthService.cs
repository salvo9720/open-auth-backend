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

    public async Task<UserNTT?> getUser(
        string username,
        string password)
    {
        UserNTT? user = await _db.Users
            .Include(x => x.userDomains)
                .ThenInclude(x => x.domain)
            .Include(x => x.userDomains)
                .ThenInclude(x => x.permission)
            .Include(x => x.devices)
            .Include(x => x.sessions)
            .FirstOrDefaultAsync(x => x.username == username);

        if (user is null)
        {
            return null;
        }

        bool isSamepassword = BCrypt.Net.BCrypt.Verify(
            password,
            user.passwordHash);


        if (isSamepassword)
        {
            return user;
        }

        return null;
    }
}