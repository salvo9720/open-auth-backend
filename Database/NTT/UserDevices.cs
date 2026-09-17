using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace open_auth_backend.Database.NTT;

public class UserDevicesNTT

{
    [Key]
    public int id { get; private set; }

    public int userId { get; private set; }
    public int deviceId { get; private set; }

    [ForeignKey(nameof(userId))]
    public ICollection<UserNTT> user { get; private set; } = new List<UserNTT>();

    [ForeignKey(nameof(deviceId))]
    public ICollection<DeviceNTT> device { get; private set; } = new List<DeviceNTT>();


}