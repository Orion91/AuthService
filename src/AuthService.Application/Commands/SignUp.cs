using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.Commands
{
    public class SignUp : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}