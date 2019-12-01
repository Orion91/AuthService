using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Application.DTO
{
	public class JwtDto
	{
		public string AccessToken { get; set; }
		public long Expires { get; set; }
	}
}
