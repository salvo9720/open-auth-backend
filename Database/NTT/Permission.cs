namespace open_auth_backend.Database.NTT;

public class PermissionNTT

{
    private int Id { get; set; }

    private int Level { get; set; }

    private ICollection<UserDomainNTT> UserDomains { get; set; }
        = new List<UserDomainNTT>();
}