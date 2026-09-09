using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.AppDbContext;
using open_auth_backend.Database.DTO;
using open_auth_backend.Database.NTT;
using System.Security.Cryptography;
namespace open_auth_backend.Controllers.Services;


public class PasswordResetService
{
    private readonly AppDbContext _db;
    private readonly EmailService _emailService;

    public PasswordResetService(AppDbContext db, EmailService emailService)
    {
        _db = db;
        _emailService = emailService;
    }

    public async Task<Boolean> getUserByEmailOrUsername(UserNTT userNtt)
    {
        string code = RandomNumberGenerator
            .GetInt32(100000, 1000000)
            .ToString();

        string tokenHash = BCrypt.Net.BCrypt.HashPassword(code);

        PasswordResetTokenNTT resetToken = new PasswordResetTokenNTT(
                0,
                userNtt.id,
                tokenHash,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(10),
                null
            );


        this._db.PasswordResetTokens.Add(resetToken);

        await this._db.SaveChangesAsync();

        return await _emailService.sendEmailPasswordResetWithCode(
            userNtt.email,
            code
        );

    }

    public async Task<UserDTO?> getUserByCode(string code)
    {
        string tokenHash = BCrypt.Net.BCrypt.HashPassword(code);

        PasswordResetTokenNTT? passwordResetTokenNTT = await this._db.PasswordResetTokens
            .Include(x=> x.user)
            .FirstOrDefaultAsync(x => x.tokenHash == tokenHash);

        if (passwordResetTokenNTT is null)
        {
            return null;
        }

        return new UserDTO(passwordResetTokenNTT.user);
    }
    // wipe incompelte development 
    public async Task<UserDTO?> updateUserpassword(string code, )
    {
        string tokenHash = BCrypt.Net.BCrypt.HashPassword(code);

        PasswordResetTokenNTT? passwordResetTokenNTT = await this._db.PasswordResetTokens
            .Include(x => x.user)
            .FirstOrDefaultAsync(x => x.tokenHash == tokenHash);

        if (passwordResetTokenNTT is null)
        {
            return null;
        }

        return new UserDTO(passwordResetTokenNTT.user);
    }



}