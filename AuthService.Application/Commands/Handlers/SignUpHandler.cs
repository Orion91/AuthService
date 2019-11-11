using System.Threading.Tasks;
using AuthService.Application.Services.Interfaces;

namespace AuthService.Application.Commands.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserService _userService;

        public SignUpHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(SignUp command)
        {
            await _userService.SignUpAsync(command.Username, command.Password, command.Email);
        }
    }
}