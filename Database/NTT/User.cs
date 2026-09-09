using System.Text.Json.Serialization;

namespace open_auth_backend.Database.NTT;

public class UserNTT
{
  
    public int Id { get; set; }

    public string Username { get; private set; } = null!;

    [JsonIgnore]
    public string PasswordHash { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public DateTime? DeletedAt { get; private set; }

    public ICollection<UserDomainNTT> UserDomains { get; private set; }
        = new List<UserDomainNTT>();

    public ICollection<DeviceNTT> Devices { get; private set; }
        = new List<DeviceNTT>();

    public ICollection<SessionNTT> Sessions { get; private set; }
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