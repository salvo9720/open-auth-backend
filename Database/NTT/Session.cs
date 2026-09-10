using System.Text.Json.Serialization;

namespace open_auth_backend.Database.NTT;

public class SessionNTT
{
    public int id { get; private set; }

    public int userId { get; private set; }

    public int deviceId { get; private set; }

    [JsonIgnore]
    public string tokenHash { get; private set; } = null!;

    public DateTime createdAt { get; private set; }

    public DateTime lastActivityAt { get; private set; }

    public DateTime expiresAt { get; set; }

    public DateTime? revokedAt { get; private set; }

    public UserNTT user { get; private set; } = null!;

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