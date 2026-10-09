using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace open_auth_backend.Database.NTT;

public class DeviceDTO
{
    public int id { get; private set; }

    public string? name { get; private set; } = null;

    public string userAgent { get; private set; } = null!;

    public int userId { get; private set; }

    public DateTime createdAt { get; private set; }

    public DateTime? deletedAt { get; private set; }


    public DeviceDTO(int userId, string? name, string userAgent, DateTime createdAt, DateTime? deletedAt)
    {
        this.userId = userId;
        this.name = name;
        this.userAgent = userAgent;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
    }

    public DeviceDTO(DeviceNTT deviceNTT)
    {
        this.userId = deviceNTT.userId;
        this.name = deviceNTT.name;
        this.userAgent = deviceNTT.userAgent;
        this.createdAt = deviceNTT.createdAt;
        this.deletedAt = deviceNTT.deletedAt;
    }

}