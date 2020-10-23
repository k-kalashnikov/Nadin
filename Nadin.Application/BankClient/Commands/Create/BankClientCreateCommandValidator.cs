using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientCreateCommandValidator : AbstractValidator<BankClientCreateCommand>
	{
		public BankClientCreateCommandValidator() 
		{
			RuleFor(x => x.FirstName)
				.NotNull()
				.NotEmpty();

			RuleFor(x => x.SecondName)
				.NotNull()
				.NotEmpty();

			RuleFor(x => x.LastName)
				.NotNull()
				.NotEmpty();
		}
	}
}
