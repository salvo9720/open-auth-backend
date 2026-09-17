using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace open_auth_backend.Database.NTT;

[Index(nameof(username), IsUnique = true)]
[Index(nameof(email), IsUnique = true)]
[Index(nameof(passwordHash), IsUnique = true)]
public class UserNTT
{
    [Key]
    public int id { get; set; }

    [MinLength(5)]
    [MaxLength(100)]
    public string username { get; private set; } = null!;

    [MinLength(10)]
    [MaxLength(100)]
    public string email { get; private set; } = null!;

    [JsonIgnore]
    [Required]
    public string passwordHash { get; private set; } = null!;

    [Required]
    public DateTime createdAt { get; private set; }

    public DateTime? deletedAt { get; private set; }

    public ICollection<UserDomainNTT> userDomains { get; private set; }
        = new List<UserDomainNTT>();

    public ICollection<DeviceNTT> devices { get; private set; }
        = new List<DeviceNTT>();
    public ICollection<SessionNTT> sessions { get; private set; }
        = new List<SessionNTT>();

    public UserNTT(int id, string username, string passwordHash, DateTime createdAt, DateTime? deletedAt, ICollection<UserDomainNTT> userDomains, ICollection<DeviceNTT> devices, ICollection<SessionNTT> sessions)
    {
        this.id = id;
        this.username = username;
        this.passwordHash = passwordHash;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
        this.userDomains = userDomains;
        this.devices = devices;
        this.sessions = sessions;
    }

    public UserNTT()
    { 
      
    }

    public void changePassword(string passwordHash) {
        this.passwordHash = passwordHash;
    }



}