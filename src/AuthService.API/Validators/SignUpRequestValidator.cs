using AuthService.API.Contracts.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.API.Validators
{
	public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
	{
		private readonly int _minLengthForPassword = 8;
		public SignUpRequestValidator()
		{
			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Username must not be empty");
			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password must not be empty")
				.MinimumLength(_minLengthForPassword).WithMessage("Password must be longer than 8 characters");
			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email must not be empty")
				.EmailAddress().WithMessage("Email must be in valid email format");
		}
	}
}
