using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace open_auth_backend.Database.NTT;

[Index(nameof(name), IsUnique = true)]
public class DomainNTT
{
    [Key]
    public int id { get; private set; }

    public string name { get; private set; } = null!;

    public ICollection<UserDomainNTT> userDomains { get; private set; }
        = new List<UserDomainNTT>();




}