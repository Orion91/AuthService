using AuthService.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Application.Services.Interfaces
{
	public interface IJwtProvider
	{
		JwtDto CreateToken(int userId, string username);
	}
}
