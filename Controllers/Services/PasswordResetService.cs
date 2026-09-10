using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.AppDbContext;
using open_auth_backend.Database.DTO;
using open_auth_backend.Database.NTT;
using System.Security.Cryptography;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
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

    public async Task<UserNTT?> getUserByCode(string code)
    {
        string tokenHash = BCrypt.Net.BCrypt.HashPassword(code);

        PasswordResetTokenNTT? passwordResetTokenNTT = await this._db.PasswordResetTokens
            .Include(x=> x.user)
            .FirstOrDefaultAsync(x => x.tokenHash == tokenHash);

        if (passwordResetTokenNTT is null)
        {
            return null;
        }

        UserNTT? userNtt = await this._db.Users
             .FirstOrDefaultAsync(x => x.id == passwordResetTokenNTT.user.id);

        if (userNtt is null)
        {
            return null;
        }


        return userNtt;
    }

    public async Task<PasswordResetTokenNTT?> validateCodeIsNotExpired(string code)
    {
        string tokenHash = BCrypt.Net.BCrypt.HashPassword(code);

        PasswordResetTokenNTT? passwordResetTokenNTT = await this._db.PasswordResetTokens
            .FirstOrDefaultAsync(x => x.expiresAt < DateTime.UtcNow);

        if (passwordResetTokenNTT is null)
        {
            return null;
        }

        return passwordResetTokenNTT;
    }

    public async Task<UserNTT?> changeUserPasswordHash(string code, UserNTT userNtt)
    {

        string tokenHash = BCrypt.Net.BCrypt.HashPassword(code);
        userNtt.changePassword(tokenHash);
        await this._db.SaveChangesAsync();

        UserNTT? updatedUser = await this._db.Users
            .FirstOrDefaultAsync(x => x.id == userNtt.id);

        return updatedUser;
    }





}