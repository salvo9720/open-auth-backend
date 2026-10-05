using Microsoft.AspNetCore.Mvc;
using open_auth_backend.Database.DTO;
using open_auth_backend.Database.NTT;
using open_auth_backend.DTO;

namespace open_auth_backend.Database.Mapper
{
    public class DeviceMapper
    {


        public List<DeviceDTO> fromUserNttToLoginResponseDto(List<DeviceNTT> deviceNtt)
        {
            List<DeviceDTO> Listdto = new List<DeviceDTO>();

            foreach (DeviceNTT ntt in deviceNtt)
            {
                DeviceDTO dto = new DeviceDTO(ntt);
                Listdto.Add(dto);
            }

            return Listdto;
        }
    }
}
