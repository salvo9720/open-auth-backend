using System.ComponentModel.DataAnnotations;

namespace open_auth_backend.Database.NTT;

public class PermissionNTT

{
    [Key]
    public int id { get; private set; }

    public int level { get; private set; }

    public ICollection<UserDomainNTT> userDomains { get; private set; }
        = new List<UserDomainNTT>();
}