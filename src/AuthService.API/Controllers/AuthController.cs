using System;
using System.Threading.Tasks;
using AuthService.API.Contracts.Requests;
using AuthService.API.Contracts.Responses;
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

				return Ok($"User {request.Username} signed up.");
			} 
			catch (Exception ex)
			{
				return Unauthorized(new ErrorResponse(ex.Message));
			}
		}

		[HttpPost("signIn")]
		public async Task<IActionResult> SignIn(SignInRequest request)
		{
			try
			{
				var command = new SignIn(request.Username, request.Password);
				var jwtToken = await _userService.SignInAsync(command);

				return Ok(new SignInResponse(jwtToken.AccessToken));
			}
			catch (Exception ex)
			{
				return BadRequest(new ErrorResponse(ex.Message));
			}
		}
	}
}