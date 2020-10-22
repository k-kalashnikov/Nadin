using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Commands
{
	public class BankDeleteCommandValidator : AbstractValidator<BankDeleteCommand>
	{
		public BankDeleteCommandValidator()
		{
			RuleFor(m => m.Id)
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}
