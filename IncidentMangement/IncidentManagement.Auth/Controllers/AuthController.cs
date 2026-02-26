using IncidentManagement.Auth.DTOs;
using IncidentManagement.Auth.Interfaces;
using IncidentManagement.Auth.Services;
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
        public async Task<IActionResult> Register([FromBody] AuthRequestDto request)
        {
            var token = await _authService.Register(request.Username, request.Password);

            if (token == null)
                return BadRequest("User already exists");

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDto request)
        {
            var token = await _authService.Login(request.Username, request.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}