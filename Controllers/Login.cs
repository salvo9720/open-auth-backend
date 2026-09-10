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

        public LoginController(ILogger<LoginController> logger, AuthService authService,UserMapper userMapper, PasswordResetService passwordResetService)
		{
			_logger = logger;
			_authService = authService;
			_userMapper = userMapper;
            _passwordResetService = passwordResetService;
        }

		[HttpPost("login", Name = "login")]
		public async Task<IActionResult> userAuth([FromBody] LoginRequestDTO request)
		{
            UserNTT? userNtt = await _authService.getUserByEmailOrUsernameAndPassword(
				request.Username,
				request.Password);

            if (userNtt is null)
            {
                return Unauthorized();
            }

            string? userAgent = HttpContext.Request.Headers["User-Agent"].FirstOrDefault();

            if (userAgent is null)
            {
                return BadRequest("userAgent missing");
            }

            DeviceNTT deviceNtt = await _authService.saveDevice(userAgent, userNtt.id);
            SessionNTT sessionNtt = await _authService.saveSession(userNtt.id, deviceNtt.id, userAgent);

            LoginResponseDTO loginResponseDto = _userMapper.fromUserNttToLoginResponseDto(userNtt);

            return Ok(loginResponseDto);

        }

		[HttpPost("forgotPassword", Name = "forgotPassword")]
		public async Task<IActionResult> forgotPasswordAndSendEmail([FromBody] string emailOrUsername)
		{
            UserNTT? userData = await _authService.getUserByEmailOrUsername(emailOrUsername);
			if (userData is null)
			{
                _logger.LogError("emailOrUsername: {EmailOrUsername}", emailOrUsername);
                return NotFound("utente non trovato");
                
			}
            Boolean resultResetEmail = await _passwordResetService.getUserByEmailOrUsername(userData);

            return Ok("segui i passaggi che ti sono stati inviati nell'indirizzo email");
        }

        [HttpPost("forgotPasswordVerifyCode", Name = "forgotPasswordVerifyCode")]
        public async Task<IActionResult> forgotPasswordVerifyCodeAndChangePassword([FromBody] string code, string password)
        {

            UserNTT? userNtt = await _passwordResetService.getUserByCode(code);
            if (userNtt is null)
            {
                _logger.LogError("utente non trovato con code: {code}", code);
                return NotFound("utente non trovato");
            }
            Boolean resultResetEmail = await _passwordResetService.getUserByEmailOrUsername(userNtt);

            if (resultResetEmail is false)
            {
                _logger.LogError("utente per update non trovato con code: {code}", code);
                return NotFound("utente per update non trovato");
            }

            UserNTT? updatedUserNtt = await _passwordResetService.changeUserPasswordHash(code,userNtt);

            if (updatedUserNtt is null)
            {
                _logger.LogError("utente per update non trovato con code: {code}", code);
                return NotFound("utente per update non trovato");
            }

            if (updatedUserNtt.passwordHash != userNtt.passwordHash)
            {
                return Ok("modifica passowrd avvenuta con successo");
            }

            throw new Exception("Si è verificato un errore nell'aggioranemnto ");
        }

        [HttpGet(Name = "DefaultLogin")]
		public string GetDefault()
		{
			return "risposta da default del controller, verifica il path di chiamata";
		}
	}
}
