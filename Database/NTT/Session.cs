namespace open_auth_backend.Database.NTT;

public class SessionNTT
{
    public int Id { get; private set; }

    public int UserId { get; private set; }

    public int DeviceId { get; private set; }

    public string TokenHash { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public DateTime LastActivityAt { get; private set; }

    public DateTime ExpiresAt { get; set; }

    public DateTime? RevokedAt { get; private set; }

    public UserNTT User { get; private set; } = null!;

    public DeviceNTT Device { get; private set; } = null!;
}