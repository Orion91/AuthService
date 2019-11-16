using System.Threading.Tasks;
using AuthService.Application.Commands;
using AuthService.Application.CQRS;
using AuthService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;

        public AuthController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            await _commandDispatcher.DispatchAsync(command);
            
            return Ok();
        }
    }
}