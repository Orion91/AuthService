using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.Commands
{
    public class SignUp : ICommand
    {
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }

		public SignUp(string username, string password, string email)
		{
			Username = username;
			Password = password;
			Email = email;
		}
    }
}