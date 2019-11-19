using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuthService.Application.Services.Implementations;
using AuthService.Application.Services.Interfaces;
using AuthService.Core.Models;
using AuthService.Core.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace AuthService.Tests.Application.Services
{
	public class UserServiceTests
	{
		[Fact]
		public async Task sign_up_async_should_invoke_add_async_on_user_repository()
		{
			var userRepositoryMock = new Mock<IUserRepository>();
			var passwordServiceMock = new Mock<IPasswordService>();

			var userService = new UserService(userRepositoryMock.Object, passwordServiceMock.Object);
			await userService.SignUpAsync("user", "secret", email: "user@email.com");

			userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
		}

		[Fact]
		public async Task sign_up_async_should_invoke_create_password_hash_on_password_service()
		{
			var userRepositoryMock = new Mock<IUserRepository>();
			var passwordServiceMock = new Mock<IPasswordService>();

			var userService = new UserService(userRepositoryMock.Object, passwordServiceMock.Object);
			await userService.SignUpAsync("user", "secret", email: "user@email.com");

			passwordServiceMock.Verify(x => x.CreatePasswordHash(It.IsAny<string>(),
																out It.Ref<byte[]>.IsAny, 
																out It.Ref<byte[]>.IsAny), Times.Once);
		}
	}
}
