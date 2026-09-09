namespace open_auth_backend.Database.NTT;

public class UserNTT
{
  
    private int Id { get; set; }

    private string Username { get; set; } = null!;

    private string PasswordHash { get; set; } = null!;

    private DateTime CreatedAt { get; set; }

    private DateTime? DeletedAt { get; set; }

    private ICollection<UserDomainNTT> UserDomains { get; set; }
        = new List<UserDomainNTT>();

    private ICollection<DeviceNTT> Devices { get; set; }
        = new List<DeviceNTT>();

    private ICollection<SessionNTT> Sessions { get; set; }
        = new List<SessionNTT>();

    public UserNTT(int id, string username, string passwordHash, DateTime createdAt, DateTime? deletedAt, ICollection<UserDomainNTT> userDomains, ICollection<DeviceNTT> devices, ICollection<SessionNTT> sessions)
    {
        Id = id;
        Username = username;
        PasswordHash = passwordHash;
        CreatedAt = createdAt;
        DeletedAt = deletedAt;
        UserDomains = userDomains;
        Devices = devices;
        Sessions = sessions;
    }

    public UserNTT()
    { 
      
    }


}