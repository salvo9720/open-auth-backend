namespace open_auth_backend.Database.NTT;

public class DomainNTT
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<UserDomainNTT> UserDomains { get; set; }
        = new List<UserDomainNTT>();
}