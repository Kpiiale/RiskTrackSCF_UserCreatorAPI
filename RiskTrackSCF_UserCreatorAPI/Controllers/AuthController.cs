using Microsoft.AspNetCore.Mvc;
using RiskTrackSCF_UserCreatorAPI.Services;
using RiskTrackSCF_UserCreatorAPI.DTOs;

namespace RiskTrackSCF_UserCreatorAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.Authenticate(request);
            if (user == null)
                return Unauthorized("Invalid admin credentials");

            return Ok(new
            {
                message = "Login successful",
                user = new { user.Id, user.FullName, user.Email }
            });
        }
    }
}
