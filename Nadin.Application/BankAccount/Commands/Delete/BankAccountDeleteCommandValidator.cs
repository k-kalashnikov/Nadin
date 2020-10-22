using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountDeleteCommandValidator : AbstractValidator<BankAccountDeleteCommand>
	{
		public BankAccountDeleteCommandValidator()
		{
			RuleFor(m => m.Id)
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}
