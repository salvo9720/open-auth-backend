namespace open_auth_backend.Database.NTT;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public ICollection<UserDomain> UserDomains { get; set; }
        = new List<UserDomain>();

    public ICollection<Device> Devices { get; set; }
        = new List<Device>();

    public ICollection<Session> Sessions { get; set; }
        = new List<Session>();
}