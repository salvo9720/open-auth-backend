namespace open_auth_backend.Database.NTT;

public class UserDomain
{
    public int UserId { get; set; }

    public int DomainId { get; set; }

    public int PermissionId { get; set; }

    public User User { get; set; } = null!;

    public Domain Domain { get; set; } = null!;

    public Permission Permission { get; set; } = null!;
}