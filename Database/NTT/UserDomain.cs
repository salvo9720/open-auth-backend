namespace open_auth_backend.Database.NTT;

public class UserDomainNTT
{
    public int UserId { get; private set; }

    public int DomainId { get; private set; }

    public int PermissionId { get; private set; }

    public UserNTT User { get; private set; } = null!;

    public DomainNTT Domain { get; private set; } = null!;

    public PermissionNTT Permission { get; private set; } = null!;
}