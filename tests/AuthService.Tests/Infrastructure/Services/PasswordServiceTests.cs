using AuthService.Infrastructure.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthService.Tests.Infrastructure.Services
{
	public class PasswordServiceTests
	{
		[Fact]
		public void invoking_twice_create_password_hash_with_the_same_password_should_create_different_hashes()
		{
			byte[] passwordHash;
			byte[] passwordSalt;
			byte[] passwordHashToCompare;
			byte[] passwordSaltToCompare;
			var password = "password";
			var passwordService = new PasswordService();

			passwordService.CreatePasswordHash(password, out passwordHash, out passwordSalt);
			passwordService.CreatePasswordHash(password, out passwordHashToCompare, out passwordSaltToCompare);

			(passwordHash != passwordHashToCompare && passwordSalt != passwordSaltToCompare).Should().BeTrue();
		}
	}
}
