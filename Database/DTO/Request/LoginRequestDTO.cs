namespace open_auth_backend.database.DTO.Request;

public class LoginRequestDTO
{
    public string emailOrUsername { get; set; } = null!;

    public string Password { get; set; } = null!;
}