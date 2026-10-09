namespace open_auth_backend.database.DTO.Request;

public class ForgotPasswordVerifyCodeRequestDTO
{
    public string code { get; set; } = null!;
    public string password { get; set; } = null!;

}