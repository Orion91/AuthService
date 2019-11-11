using System.Threading.Tasks;
using AuthService.Application.Commands;
using AuthService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            return Ok();
        }
    }
}