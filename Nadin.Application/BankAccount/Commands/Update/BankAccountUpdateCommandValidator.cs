using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Commands
{

	public class BankAccountUpdateCommandValidator : AbstractValidator<BankAccountUpdateCommand>
	{
		public BankAccountUpdateCommandValidator()
		{
			RuleFor(x => x.AccountType)
				.NotNull();

			RuleFor(x => x.BankClientId)
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(x => x.BankId)
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(x => x.Id)
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}
