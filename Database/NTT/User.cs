namespace open_auth_backend.Database.NTT;

public class UserNTT
{
    public int Id { get; set; }

    public required string Username { get; set; };

    public required string PasswordHash { get; set; };

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public ICollection<UserDomainNTT> UserDomains { get; set; }
        = new List<UserDomainNTT>();

    public ICollection<DeviceNTT> Devices { get; set; }
        = new List<DeviceNTT>();

    public ICollection<SessionNTT> Sessions { get; set; }
        = new List<SessionNTT>();
}