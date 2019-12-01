using AuthService.API.Contracts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.API.Validators
{
	public class SignInRequestValidator : AbstractValidator<SignInRequest>
	{
		public SignInRequestValidator()
		{
			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Username can not be empty");
			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password can not be empty");
		}
	}
}
