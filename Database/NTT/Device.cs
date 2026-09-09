namespace open_auth_backend.Database.NTT;

public class DeviceNTT
{
    private int Id { get; set; }

    private int UserId { get; set; }

    private string Name { get; set; } = null!;

    private DateTime CreatedAt { get; set; }

    private DateTime? DeletedAt { get; set; }

    private UserNTT User { get; set; } = null!;

    public ICollection<SessionNTT> Sessions { get; set; }
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