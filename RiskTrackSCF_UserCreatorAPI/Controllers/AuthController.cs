using Microsoft.AspNetCore.Mvc;
using RiskTrackSCF_UserCreatorAPI.Services;
using RiskTrackSCF_UserCreatorAPI.DTOs;

namespace RiskTrackSCF_UserCreatorAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        // Inyección de dependencia para el servicio de usuario.
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Delega la lógica de autenticación al servicio de usuario.
            var user = _userService.Authenticate(request);
            if (user == null)
                return Unauthorized("Invalid admin credentials");
            // Si la autenticación es exitosa, devuelve una respuesta 200 OK con los datos del usuario.
            return Ok(new
            {
                message = "Login successful",
                user = new { user.UserId, user.Username, user.Email, user.Role}
            });
        }
    }
}
