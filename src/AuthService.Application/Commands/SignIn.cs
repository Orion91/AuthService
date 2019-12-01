using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Application.Commands
{
	public class SignIn : ICommand
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public SignIn(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}
