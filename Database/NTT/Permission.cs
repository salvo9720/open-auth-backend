namespace open_auth_backend.Database.NTT;

public class Permission
{
    public int Id { get; set; }

    public int Level { get; set; }

    public ICollection<UserDomain> UserDomains { get; set; }
        = new List<UserDomain>();
}