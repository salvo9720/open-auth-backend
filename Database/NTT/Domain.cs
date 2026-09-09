namespace open_auth_backend.Database.NTT;

public class DomainNTT
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public ICollection<UserDomainNTT> UserDomains { get; private set; }
        = new List<UserDomainNTT>();




}