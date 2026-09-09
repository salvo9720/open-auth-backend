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

        public LoginController()
        {
        }

        public LoginController(ILogger<LoginController> logger)
		{
			_logger = logger;
		}

		[HttpPost("login", Name = "login")]
		public async Task<IActionResult> userAuth([FromBody] LoginRequestDTO request)
		{
            bool valid = await _authService.ValidateCredentialsAsync(
				request.Username,
				request.Password);

            if (!valid)
            {
                return Unauthorized();
            }

            return Ok(new
				{
					message = "Login effettuato"
				}
			);

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
