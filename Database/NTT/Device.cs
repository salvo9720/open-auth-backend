namespace open_auth_backend.Database.NTT;

public class DeviceNTT
{
    public int Id { get; private set; }

    public int UserId { get; private set; }

    public string Name { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public DateTime? DeletedAt { get; private set; }

    public UserNTT User { get; private set; } = null!;

    public ICollection<SessionNTT> Sessions { get; private set; }
        = new List<SessionNTT>();

    public DeviceNTT(int id, int userId, string name, DateTime createdAt, DateTime? deletedAt, UserNTT user, ICollection<SessionNTT> sessions)
    {
        Id = id;
        UserId = userId;
        Name = name;
        CreatedAt = createdAt;
        DeletedAt = deletedAt;
        User = user;
        Sessions = sessions;
    }

    public DeviceNTT()
    {
       
    }


}