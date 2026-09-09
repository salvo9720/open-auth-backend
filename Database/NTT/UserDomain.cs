namespace open_auth_backend.Database.NTT;

public class UserDomainNTT
{
    private int UserId { get; set; }

    private int DomainId { get; set; }

    private int PermissionId { get; set; }

    private UserNTT User { get; set; } = null!;

    private DomainNTT Domain { get; set; } = null!;

    private PermissionNTT Permission { get; set; } = null!;
}