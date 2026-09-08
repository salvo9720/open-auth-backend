namespace open_auth_backend.Database.NTT;

public class SessionNTT
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int DeviceId { get; set; }

    public string TokenHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime LastActivityAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public DateTime? RevokedAt { get; set; }

    public UserNTT User { get; set; } = null!;

    public DeviceNTT Device { get; set; } = null!;
}