namespace open_auth_backend.Database.NTT;

public class SessionDTO
{
    public int id { get; private set; }

    public int userId { get; private set; }

    public int deviceId { get; private set; }

    public DateTime createdAt { get; private set; }

    public DateTime lastActivityAt { get; private set; }

    public DateTime expiresAt { get; set; }

    public DateTime? revokedAt { get; private set; }

    public UserNTT user { get; private set; } = null!;

    public DeviceNTT device { get; private set; } = null!;

    public SessionDTO(int id, int userId, int deviceId, DateTime createdAt, DateTime lastActivityAt, DateTime expiresAt, DateTime? revokedAt)
    {
        this.id = id;
        this.userId = userId;
        this.deviceId = deviceId;
        this.createdAt = createdAt;
        this.lastActivityAt = lastActivityAt;
        this.expiresAt = expiresAt;
        this.revokedAt = revokedAt;
    }
}