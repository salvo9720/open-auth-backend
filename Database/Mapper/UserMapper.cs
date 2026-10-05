using Microsoft.AspNetCore.Mvc;
using open_auth_backend.Database.DTO;
using open_auth_backend.Database.NTT;
using open_auth_backend.DTO;

namespace open_auth_backend.Database.Mapper
{
    public class UserMapper
    {

        
        public LoginResponseDTO fromUserNttToLoginResponseDto(UserNTT userNtt, List<DeviceDTO> deviceNtt)
        {
            UserDTO userDTO = new UserDTO(userNtt);

            List<string> domains = userNtt.userDomains
                .Select(x => x.domain.name)
                .ToList();

            int permission = userNtt.userDomains
                .Select(x => x.permission.level)
                .FirstOrDefault();

            List<SessionDTO> sessionDto = new List<SessionDTO>();

            foreach (SessionNTT session in userNtt.sessions)
            {
                SessionDTO dto = new SessionDTO(session);
                sessionDto.Add(dto);
            }

            return new LoginResponseDTO(userDTO, deviceNtt, permission, sessionDto, domains);


        }
    }
}
