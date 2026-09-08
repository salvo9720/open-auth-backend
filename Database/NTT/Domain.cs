namespace open_auth_backend.Database.NTT;

public class Domain
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<UserDomain> UserDomains { get; set; }
        = new List<UserDomain>();
}