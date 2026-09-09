namespace open_auth_backend.Database.NTT;

public class DomainNTT
{
    private int Id { get; set; }

    private string Name { get; set; } = null!;

    private ICollection<UserDomainNTT> UserDomains { get; set; }
        = new List<UserDomainNTT>();




}