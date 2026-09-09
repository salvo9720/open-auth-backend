namespace open_auth_backend.Database.NTT;

public class SessionNTT
{
    private int Id { get; set; }

    private int UserId { get; set; }

    private int DeviceId { get; set; }

    private string TokenHash { get; set; } = null!;

    private DateTime CreatedAt { get; set; }

    private DateTime LastActivityAt { get; set; }

    private DateTime ExpiresAt { get; set; }

    private DateTime? RevokedAt { get; set; }

    private UserNTT User { get; set; } = null!;

    private DeviceNTT Device { get; set; } = null!;
}