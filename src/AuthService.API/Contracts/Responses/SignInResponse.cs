using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.API.Contracts.Responses
{
	public class SignInResponse
	{
		public string AccessToken { get; private set; }

		public SignInResponse(string accessToken)
		{
			AccessToken = accessToken;
		}
	}
}
