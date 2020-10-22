using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountCreateCommandValidator : AbstractValidator<BankAccountCreateCommand>
	{
		public BankAccountCreateCommandValidator() 
		{
			RuleFor(x => x.AccountType)
				.NotNull();

			RuleFor(x => x.BankClientId)
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(x => x.BankId)
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}
