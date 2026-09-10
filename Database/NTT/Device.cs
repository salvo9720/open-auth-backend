using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace open_auth_backend.Database.NTT;

public class DeviceNTT
{
    public int id { get; private set; }

    public string? name { get; private set; } = null;

    public string userAgent { get; private set; } = null!;

    public int userId { get; private set; }

    public DateTime createdAt { get; private set; }

    public DateTime? deletedAt { get; private set; }

    public ICollection<UserNTT> user { get; private set; } = new List<UserNTT>();

    public ICollection<SessionNTT> sessions { get; private set; } = new List<SessionNTT>();

    public DeviceNTT(int id, int userId, string? name, string userAgent, DateTime createdAt, DateTime? deletedAt, ICollection<UserNTT> user, ICollection<SessionNTT> sessions)
    {
        this.id = id;
        this.userId = userId;
        this.name = name;
        this.userAgent = userAgent;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
        this.user = user;
        this.sessions = sessions;
    }

    public DeviceNTT(int userId, string? name, string userAgent, DateTime createdAt, DateTime? deletedAt)
    {
        this.userId = userId;
        this.name = name;
        this.userAgent = userAgent;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
    }

    public DeviceNTT()
    {
       
    }


}