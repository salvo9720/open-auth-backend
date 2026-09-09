namespace open_auth_backend.Database.NTT;

public class PermissionNTT

{
    public int Id { get; private set; }

    public int Level { get; private set; }

    public ICollection<UserDomainNTT> UserDomains { get; private set; }
        = new List<UserDomainNTT>();
}