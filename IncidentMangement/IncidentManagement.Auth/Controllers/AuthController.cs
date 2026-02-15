using IncidentManagement.Auth.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var token = await _authService.Register(username, password);

            if (token == null)
                return BadRequest("User already exists");

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _authService.Login(username, password);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}