using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using open_auth_backend.Controllers.Services;
using open_auth_backend.DTO;
using open_auth_backend.Database.NTT;
using open_auth_backend.Database.DTO;
using open_auth_backend.Database.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace open_auth_backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LoginController : ControllerBase
	{
		private readonly ILogger<LoginController> _logger;
		private readonly AuthService _authService;
		private readonly UserMapper _userMapper;
		private readonly PasswordResetService _passwordResetService;

        public LoginController(ILogger<LoginController> logger, AuthService authService,UserMapper userMapper)
		{
			_logger = logger;
			_authService = authService;
			_userMapper = userMapper;
        }

		[HttpPost("login", Name = "login")]
		public async Task<IActionResult> userAuth([FromBody] LoginRequestDTO request)
		{
            UserNTT? loginResponse = await _authService.getUserByEmailOrUsernameAndPassword(
				request.Username,
				request.Password);

            if (loginResponse is null)
            {
                return Unauthorized();
            }

			LoginResponseDTO loginResponseDto = _userMapper.fromUserNttToLoginResponseDto(loginResponse);
            return Ok(loginResponse);

        }

		[HttpPost("forgotPassword", Name = "forgotPassword")]
		public async Task<IActionResult> forgotPassword([FromBody] string emailOrUsername)
		{
            UserNTT? userData = await _authService.getUserByEmailOrUsername(emailOrUsername);
			if (userData is null)
			{
                _logger.LogError("emailOrUsername: {EmailOrUsername}", emailOrUsername);
                
			}
            Boolean resultResetEmail = await _passwordResetService.getUserByEmailOrUsername(userData);


            // come viene gestito questo in un ambiemnte serio
            // 1) inserisci la mail di registrazione 
            // 2) inseirisci il codice ricevuto via email per confermare sia tu
            // 3) modifica della password con la nuova password
            return Ok("segui i passaggi che ti sono stati inviati nell'indirizzo email");
        }

        [HttpPost("forgotPasswordVerifyCode", Name = "forgotPasswordVerifyCode")]
        public async Task<IActionResult> forgotPassword([FromBody] string code)
        {

            UserNTT? userData = await _authService.getUserByEmailOrUsername(emailOrUsername);
            if (userData is null)
            {
                _logger.LogError("emailOrUsername: {EmailOrUsername}", emailOrUsername);

            }
            Boolean resultResetEmail = await _passwordResetService.getUserByEmailOrUsername(userData);


            // come viene gestito questo in un ambiemnte serio
            // 1) inserisci la mail di registrazione 
            // 2) inseirisci il codice ricevuto via email per confermare sia tu
            // 3) modifica della password con la nuova password
            return Ok("segui i passaggi che ti sono stati inviati nell'indirizzo email");
        }

        [HttpGet(Name = "DefaultLogin")]
		public string GetDefault()
		{
			return "rispsota da default del controller, verifica il path di chiamata";
		}
	}
}
