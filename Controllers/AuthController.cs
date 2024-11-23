using Microsoft.AspNetCore.Mvc;
using NexCart.DTOs.Auth;
using NexCart.Services.Interfaces;

namespace NexCart.Controllers
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

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpRequestDto signUpRequest)
        {
            var result = await _authService.SignUpAsync(signUpRequest);
            return result ? Ok("User registered successfully.") : BadRequest("Registration failed.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            var authResponse = await _authService.LoginAsync(loginRequest);
            return Ok(authResponse);
        }

        [HttpPost("deactivate")]
        [RoleAuthorize("Admin")]
        public async Task<IActionResult> DeactivateUser(int userId)
        {
            await _userRepository.DeactivateUserAsync(userId);
            return Ok("User deactivated successfully.");
        }

    }
}

