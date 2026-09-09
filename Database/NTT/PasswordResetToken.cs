namespace open_auth_backend.Database.NTT;

public class PasswordResetTokenNTT
{
    public int id { get; private set; }

    public int userId { get; private set; }

    public string tokenHash { get; private set; } = null!;

    public DateTime createdAt { get; private set; }

    public DateTime expiresAt { get; private set; }

    public DateTime? usedAt { get; private set; }

    public UserNTT user { get; private set; } = null!;

    public PasswordResetTokenNTT(
        int id,
        int userId,
        string tokenHash,
        DateTime createdAt,
        DateTime expiresAt,
        DateTime? usedAt,
        UserNTT user)
    {
        this.id = id;
        this.userId = userId;
        this.tokenHash = tokenHash;
        this.createdAt = createdAt;
        this.expiresAt = expiresAt;
        this.usedAt = usedAt;
        this.user = user;
    }

    public PasswordResetTokenNTT()
    {
    }
}