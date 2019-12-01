using System;
using System.Threading.Tasks;
using AuthService.API.Contracts.Requests;
using AuthService.Application.Commands;
using AuthService.Application.CQRS;
using AuthService.Application.Services.Interfaces;
using AuthService.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly ICommandDispatcher _commandDispatcher;

		public AuthController(IUserService userService, ICommandDispatcher commandDispatcher)
		{
			_userService = userService;
			_commandDispatcher = commandDispatcher;
		}

		[HttpPost("signUp")]
		public async Task<IActionResult> SignUp(SignUpRequest request)
		{
			try
			{
				var command = new SignUp(request.Username, request.Password, request.Email);
				await _commandDispatcher.DispatchAsync(command);
			} 
			catch (Exception ex)
			{
				return Unauthorized(ex.Message);
			}

			return Ok($"User {request.Username} signed up.");
		}

		[HttpPost("signIn")]
		public async Task<IActionResult> SignIn(SignInRequest request)
		{
			try
			{
				var command = new SignIn(request.Username, request.Password);
				await _commandDispatcher.DispatchAsync(command);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> Get(string username)
		{
			var user = await _userService.UserExistsAsync(username);
			if (!user)
			{
				return NotFound();
			}

			return Ok(user);
		}
	}
}