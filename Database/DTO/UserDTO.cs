using Microsoft.AspNetCore.Http.HttpResults;
using open_auth_backend.Database.NTT;
using System.Text.Json.Serialization;

namespace open_auth_backend.Database.DTO;

public class UserDTO
{
  
    public int id { get; set; }

    public string username { get; private set; } = null!;

    public DateTime createdAt { get; private set; }

    public DateTime? deletedAt { get; private set; }



    public UserDTO(int id, string username, DateTime createdAt, DateTime? deletedAt)
    {
        this.id = id;
        this.username = username;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
    }

    public UserDTO(UserNTT userNtt)
    {
        id = userNtt.id;
        username = userNtt.username;
        createdAt = userNtt.createdAt;
        deletedAt = userNtt.deletedAt;
    }
}