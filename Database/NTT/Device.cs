namespace open_auth_backend.Database.NTT;

public class DeviceNTT
{
    public int id { get; private set; }

    public int userId { get; private set; }

    public string name { get; private set; } = null!;

    public DateTime createdAt { get; private set; }

    public DateTime? deletedAt { get; private set; }

    public UserNTT user { get; private set; } = null!;

    public ICollection<SessionNTT> sessions { get; private set; }
        = new List<SessionNTT>();

    public DeviceNTT(int id, int userId, string name, DateTime createdAt, DateTime? deletedAt, UserNTT user, ICollection<SessionNTT> sessions)
    {
        this.id = id;
        this.userId = userId;
        this.name = name;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
        this.user = user;
        this.sessions = sessions;
    }

    public DeviceNTT()
    {
       
    }


}