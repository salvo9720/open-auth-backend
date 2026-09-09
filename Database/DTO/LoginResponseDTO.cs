using open_auth_backend.Database.NTT;

namespace open_auth_backend.DTO;

public class LoginResponseDTO
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DeviceNTT Device { get; set; } = new DeviceNTT();

    public DomainNTT Domain { get; set; } = new DomainNTT();

    public PermissionNTT Permission { get; set; } = new PermissionNTT();

    public SessionNTT Session { get; set; } = new SessionNTT();

    public UserDomainNTT UserDomain { get; set; } = new UserDomainNTT();
}