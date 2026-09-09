namespace open_auth_backend.Database.NTT;

public class UserDomainNTT
{
    public int userId { get; private set; }

    public int domainId { get; private set; }

    public int permissionId { get; private set; }

    public UserNTT user { get; private set; } = null!;

    public DomainNTT domain { get; private set; } = null!;

    public PermissionNTT permission { get; private set; } = null!;
}