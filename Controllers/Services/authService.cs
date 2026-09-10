using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.AppDbContext;
using open_auth_backend.Database.NTT;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
namespace open_auth_backend.Controllers.Services;


public class AuthService
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UserNTT?> getUserByEmailOrUsernameAndPassword(
        string emailOrUsername,
        string password)
    {
        UserNTT? user = await _db.Users
            .Include(x => x.userDomains)
                .ThenInclude(x => x.domain)
            .Include(x => x.userDomains)
                .ThenInclude(x => x.permission)
            .Include(x => x.devices)
            .Include(x => x.sessions)
            .FirstOrDefaultAsync(x => x.username == emailOrUsername || x.email == emailOrUsername);

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

    public async Task<UserNTT?> getUserByEmailOrUsername(
     string emailOrUsername)
    {
        UserNTT? user = await _db.Users
            .FirstOrDefaultAsync(x => x.username == emailOrUsername);

        if (user is null)
        {
            return null;
        } else if (user.username.Length > 0)
        {
            return user;
        }

        return null;
    }

    public async Task<DeviceNTT> saveDevice(string userAgent, int userId)
    {
        DeviceNTT deviceNtt = new DeviceNTT(userId, null, userAgent,DateTime.UtcNow, null);
        _db.Devices.Add(deviceNtt);
        await _db.SaveChangesAsync();
        return deviceNtt;
    }

    public async Task<SessionNTT> saveSession(int userId, int deviceId,string userAgent)
    {
        string inputTokenHash = userAgent + DateTime.UtcNow.ToString();
        byte[] bytes = Encoding.UTF8.GetBytes(inputTokenHash);
        byte[] hash = SHA256.HashData(bytes);
        string tokenHash = Convert.ToHexString(hash).ToLowerInvariant();

        SessionNTT? sessionNtt = new SessionNTT(userId, deviceId, tokenHash, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow.AddMonths(1), null);
        _db.Sessions.Add(sessionNtt);
        await _db.SaveChangesAsync();

        return sessionNtt;
    }
}