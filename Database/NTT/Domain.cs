namespace open_auth_backend.Database.NTT;

public class DomainNTT
{
    public int id { get; private set; }

    public string name { get; private set; } = null!;

    public ICollection<UserDomainNTT> userDomains { get; private set; }
        = new List<UserDomainNTT>();




}