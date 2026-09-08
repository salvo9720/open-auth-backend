namespace open_auth_backend.Database.NTT;

public class Device
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public User User { get; set; } = null!;

    public ICollection<Session> Sessions { get; set; }
        = new List<Session>();
}