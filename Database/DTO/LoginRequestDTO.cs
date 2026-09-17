namespace open_auth_backend.DTO;

public class LoginRequestDTO
{
    public string emailOrUsername { get; set; } = null!;

    public string Password { get; set; } = null!;
}