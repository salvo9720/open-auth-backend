namespace open_auth_backend.Database.NTT;

public class PermissionNTT

{
    public int Id { get; set; }

    public int Level { get; set; }

    public ICollection<UserDomainNTT> UserDomains { get; set; }
        = new List<UserDomainNTT>();
}