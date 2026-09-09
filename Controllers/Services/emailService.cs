using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.AppDbContext;
using open_auth_backend.Database.NTT;
using System.Net.Mail;
using System.Security.Cryptography;
using MailKit.Net.Smtp;
using System.Net.Mail;
using MimeKit;
namespace open_auth_backend.Controllers.Services;


public class EmailService
{
    private readonly AppDbContext _db;

    public EmailService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Boolean> sendEmailPasswordResetWithCode(
    string email, string code)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("OpenAuth", "la-tua-email@example.com")); 
        message.To.Add(MailboxAddress.Parse(email)); 
        message.Subject = "Codice recupero password"; 
        message.Body = new TextPart("plain") { Text = $"Il tuo codice per recuperare la password è: {code}" };
        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        await smtp.ConnectAsync("smtp.example.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync("la-tua-email@example.com", "LA-TUA-PASSWORD-O-API-KEY"); 
        await smtp.SendAsync(message); 
        await smtp.DisconnectAsync(true);

        return true;
    }



}