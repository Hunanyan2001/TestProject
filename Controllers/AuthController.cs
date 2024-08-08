using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TestProject.Interfaces;
using TestProject.Models;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            return Ok(await _authService.LoginAsync(loginModel));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            return Ok(await _authService.RegisterAsync(registerModel));
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return null;
        }
    }
}