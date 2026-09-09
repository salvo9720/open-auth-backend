using Microsoft.AspNetCore.Mvc;
using open_auth_backend.Database.DTO;
using open_auth_backend.Database.NTT;
using open_auth_backend.DTO;

namespace open_auth_backend.Database.Mapper
{
    public class UserMapper
    {

        
        public LoginResponseDTO fromUserNttToLoginResponseDto(UserNTT userNtt)
        {
            UserDTO userDTO = new UserDTO(userNtt);

            List<string> domains = userNtt.userDomains
                .Select(x => x.domain.name)
                .ToList();

            int permission = userNtt.userDomains
                .Select(x => x.permission.level)
                .FirstOrDefault();

            List<DeviceNTT> devices = userNtt.devices.ToList();
            List<SessionDTO> sessionDto = new List<SessionDTO>();

            foreach (SessionNTT session in userNtt.sessions)
            {
                SessionDTO dto = new SessionDTO(session);
                sessionDto.Add(dto);
            }

            return new LoginResponseDTO(userDTO, devices, permission, sessionDto, domains);
        }
    }
}
