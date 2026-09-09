using open_auth_backend.Database.NTT;
using open_auth_backend.Database.DTO;

namespace open_auth_backend.DTO;

public class LoginResponseDTO
{
   
    public UserDTO userDto { get; set; } = null!;

    public List<DeviceNTT> device { get; set; } =  null!;

    public int permission { get; set; }

    public List<SessionDTO> session { get; set; } =  null!;

    public List<string> userDomain { get; set; } =  null!;

    public LoginResponseDTO(UserDTO userDto, List<DeviceNTT> device, int permission, List<SessionDTO> sessionDto, List<string> userDomain)
    {
        this.userDto = userDto;
        this.device = device;
        this.permission = permission;
        this.session = sessionDto;
        this.userDomain = userDomain;
    }
}