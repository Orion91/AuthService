using AuthService.Application.DTO;
using AuthService.Application.Services.Interfaces;
using AuthService.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Infrastructure.Services
{
	public class JwtProvider : IJwtProvider
	{
		private readonly JwtSettings _jwtSettings;

		public JwtProvider(JwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}
		public JwtDto CreateToken(int userId, string username)
		{
			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
				new Claim(ClaimTypes.Name, username)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.TokenKey));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = creds
			};

			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return new JwtDto
			{
				AccessToken = tokenHandler.WriteToken(token)
			};
		}
	}
}
