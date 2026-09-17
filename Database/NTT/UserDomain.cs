using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace open_auth_backend.Database.NTT;

public class UserDomainNTT
{
    [Key]
    public int id { get; private set; }
    public int userId { get; private set; }

    public int domainId { get; private set; }

    public int permissionId { get; private set; }

    [ForeignKey(nameof(userId))]
    public UserNTT user { get; private set; } = null!;

    [ForeignKey(nameof(domainId))]
    public DomainNTT domain { get; private set; } = null!;

    [ForeignKey(nameof(permissionId))]
    public PermissionNTT permission { get; private set; } = null!;
}