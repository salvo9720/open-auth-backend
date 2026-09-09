using Microsoft.AspNetCore.Http.HttpResults;
using open_auth_backend.Database.NTT;
using System.Text.Json.Serialization;

namespace open_auth_backend.Database.DTO;

public class UserDTO
{
  
    public int id { get; set; }

    public string username { get; private set; } = null!;

    public DateTime createdAt { get; private set; }

    public DateTime? deletedAt { get; private set; }

    public ICollection<UserDomainNTT> userDomains { get; private set; }
        = new List<UserDomainNTT>();

    public ICollection<DeviceNTT> devices { get; private set; }
        = new List<DeviceNTT>();

    public ICollection<SessionNTT> sessions { get; private set; }
        = new List<SessionNTT>();

    public UserDTO(int id, string username, DateTime createdAt, DateTime? deletedAt, ICollection<UserDomainNTT> userDomains, ICollection<DeviceNTT> devices, ICollection<SessionNTT> sessions)
    {
        this.id = id;
        this.username = username;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
        this.userDomains = userDomains;
        this.devices = devices;
        this.sessions = sessions;
    }

    public UserDTO(UserNTT userNtt)
    {
        id = userNtt.id;
        username = userNtt.username;
        createdAt = userNtt.createdAt;
        deletedAt = userNtt.deletedAt;
        userDomains = userNtt.userDomains;
        devices = userNtt.devices;
        sessions = userNtt.sessions;
    }


}