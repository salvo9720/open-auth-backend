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
            .Include(x => x.UserDomains)
                .ThenInclude(x => x.Domain)
            .Include(x => x.UserDomains)
                .ThenInclude(x => x.Permission)
            .Include(x => x.Devices)
            .Include(x => x.Sessions)
            .FirstOrDefaultAsync(x => x.Username == username);

        if (user is null)
        {
            return null;
        }

        bool isSamepassword = BCrypt.Net.BCrypt.Verify(
            password,
            user.PasswordHash);


        if (isSamepassword)
        {
            return user;
        }

        return null;
    }
}