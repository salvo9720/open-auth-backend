namespace open_auth_backend.Database.NTT;

public class DeviceNTT
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public UserNTT User { get; set; } = null!;

    public ICollection<SessionNTT> Sessions { get; set; }
        = new List<SessionNTT>();
}