using Microsoft.AspNetCore.Mvc;
using RiskTrackSCF_UserCreatorAPI.DTOs;
using RiskTrackSCF_UserCreatorAPI.Services;

namespace RiskTrackSCF_UserCreatorAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateUserRequest request)
        {
            _userService.CreateUser(request);
            return Ok("User created successfully");
        }
    }
}
