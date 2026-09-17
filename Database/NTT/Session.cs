using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace open_auth_backend.Database.NTT;

[Index(nameof(tokenHash), IsUnique = true)]

public class SessionNTT
{
    [Key]
    public int id { get; private set; }

    public int userId { get; private set; }

    public int deviceId { get; private set; }

    [JsonIgnore]
    public string tokenHash { get; private set; } = null!;

    public DateTime createdAt { get; private set; }

    public DateTime lastActivityAt { get; private set; }

    public DateTime expiresAt { get; set; }

    public DateTime? revokedAt { get; private set; }

    [ForeignKey(nameof(userId))]
    public UserNTT user { get; private set; } = null!;

    [ForeignKey(nameof(deviceId))]
    public DeviceNTT device { get; private set; } = null!;

    public SessionNTT(int userId, int deviceId, string tokenHash, DateTime createdAt, DateTime lastActivityAt, DateTime expiresAt, DateTime? revokedAt)
    {
        this.userId = userId;
        this.deviceId = deviceId;
        this.tokenHash = tokenHash;
        this.createdAt = createdAt;
        this.lastActivityAt = lastActivityAt;
        this.expiresAt = expiresAt;
        this.revokedAt = revokedAt;
    }
}