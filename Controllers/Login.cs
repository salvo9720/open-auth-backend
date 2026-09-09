using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using open_auth_backend.Controllers.Services;
using open_auth_backend.DTO;
using open_auth_backend.Database.NTT;

namespace open_auth_backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LoginController : ControllerBase
	{
		private readonly ILogger<LoginController> _logger;
		private readonly AuthService _authService;

        public LoginController(ILogger<LoginController> logger, AuthService authService)
		{
			_logger = logger;
			_authService = authService;
        }

		[HttpPost("login", Name = "login")]
		public async Task<IActionResult> userAuth([FromBody] LoginRequestDTO request)
		{
            UserNTT? loginResponse = await _authService.getUser(
				request.Username,
				request.Password);

            if (loginResponse is null)
            {
                return Unauthorized();
            }

            return Ok(loginResponse);

        }

		[HttpGet("forgotPassword", Name = "forgotPassword")]
		public string forgotPassword()
		{
			return "2";
		}

		[HttpGet(Name = "DefaultLogin")]
		public string GetDefault()
		{
			return "rispsota da default del controller, verifica il path di chiamata";
		}
	}
}
