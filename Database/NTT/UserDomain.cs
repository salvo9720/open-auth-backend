namespace open_auth_backend.Database.NTT;

public class UserDomainNTT
{
    public int UserId { get; set; }

    public int DomainId { get; set; }

    public int PermissionId { get; set; }

    public UserNTT User { get; set; } = null!;

    public DomainNTT Domain { get; set; } = null!;

    public PermissionNTT Permission { get; set; } = null!;
}