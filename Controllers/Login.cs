using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using open_auth_backend.Controllers.Services;
using open_auth_backend.DTO;
using open_auth_backend.Database.NTT;
using open_auth_backend.Database.DTO;
using open_auth_backend.Database.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
using open_auth_backend.database.DTO.Request;

namespace open_auth_backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LoginController : ControllerBase
	{
		private readonly ILogger<LoginController> _logger;
		private readonly AuthService _authService;
		private readonly UserMapper _userMapper;
		private readonly DeviceMapper _deviceMapper;
        private readonly PasswordResetService _passwordResetService;

        private readonly IConfiguration _configuration;

        public LoginController(ILogger<LoginController> logger, AuthService authService,UserMapper userMapper, DeviceMapper deviceMapper, PasswordResetService passwordResetService, IConfiguration configuration)
		{
			_logger = logger;
			_authService = authService;
			_userMapper = userMapper;
            _deviceMapper = deviceMapper;
            _passwordResetService = passwordResetService;
            _configuration = configuration;

        }

        [HttpPost("auth", Name = "auth")]
		public async Task<IActionResult> userAuth([FromBody] LoginRequestDTO request)
		{
            UserNTT? userNtt = await _authService.getUserByEmailOrUsernameAndPassword(
				request.emailOrUsername,
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

            DeviceNTT newDeviceNtt = await _authService.saveDevice(userAgent, userNtt.id);
            List<DeviceNTT> deviceNtt = await _authService.getAllDevicesForUser(userNtt.id);
            List<DeviceDTO> deviceDto = _deviceMapper.fromUserNttToLoginResponseDto(deviceNtt);

            SessionNTT sessionNtt = await _authService.saveSession(userNtt.id, newDeviceNtt.id, userAgent);

            LoginResponseDTO loginResponseDto = _userMapper.fromUserNttToLoginResponseDto(userNtt, deviceDto);

            return Ok(loginResponseDto);

        }

		[HttpPost("forgotPassword", Name = "forgotPassword")]
		public async Task<IActionResult> forgotPasswordAndSendEmail([FromBody] ForgotPasswordRequestDTO forgotPasswordDto)
		{
            UserNTT? userData = await _authService.getUserByEmailOrUsername(forgotPasswordDto.emailOrUsername);
			if (userData is null)
			{
                _logger.LogError("emailOrUsername: {EmailOrUsername}", forgotPasswordDto.emailOrUsername);
                return NotFound("utente non trovato");
                
			}
            Boolean isDevMode = _configuration.GetValue<Boolean>("isDevMode");
            Boolean resultResetEmail = await _passwordResetService.getUserByEmailOrUsername(userData, isDevMode, _logger);

            return Ok("segui i passaggi che ti sono stati inviati nell'indirizzo email");
        }

        [HttpPost("forgotPasswordVerifyCode", Name = "forgotPasswordVerifyCode")]
        public async Task<IActionResult> forgotPasswordVerifyCodeAndChangePassword([FromBody] ForgotPasswordVerifyCodeRequestDTO forgotPasswordVerifyCodeRequestDto)
        {

            UserNTT? userNtt = await _passwordResetService.getUserByCode(forgotPasswordVerifyCodeRequestDto.code);
            if (userNtt is null)
            {
                _logger.LogError("utente non trovato con code: {code}", forgotPasswordVerifyCodeRequestDto.code);
                return NotFound("utente non trovato");
            }
            string oldPasswrod = userNtt.passwordHash;
            Boolean isDevMode = _configuration.GetValue<Boolean>("isDevMode");
            Boolean resultResetEmail = await _passwordResetService.getUserByEmailOrUsername(userNtt, isDevMode, _logger);

            if (resultResetEmail is false)
            {
                _logger.LogError("utente per update non trovato con code: {code}", forgotPasswordVerifyCodeRequestDto.code);
                return NotFound("utente per update non trovato");
            }

            UserNTT? updatedUserNtt = await _passwordResetService.changeUserPasswordHash(forgotPasswordVerifyCodeRequestDto.code,userNtt);

            if (updatedUserNtt is null)
            {
                _logger.LogError("utente per update non trovato con code: {code}", forgotPasswordVerifyCodeRequestDto.code);
                return NotFound("utente per update non trovato");
            }

            if (updatedUserNtt.passwordHash != oldPasswrod)
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

        [HttpGet("{defaultRespone}", Name = "GetDefaultResponseIfMethodNotExist")]
        public string GetDefaultResponseIfMethodNotExist()
        {
            return "risposta da default del controller, verifica il path di chiamata";
        }
    }
}
