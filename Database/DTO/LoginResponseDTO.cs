using open_auth_backend.Database.NTT;

namespace open_auth_backend.DTO;

public class LoginResponseDTO
{
    public string Username { get; set; } = null!;

    public DeviceNTT Device { get; set; } =  null!;

    public int Permission { get; set; }

    public SessionNTT Session { get; set; } =  null!;

    public List<string> UserDomain { get; set; } =  null!;
}