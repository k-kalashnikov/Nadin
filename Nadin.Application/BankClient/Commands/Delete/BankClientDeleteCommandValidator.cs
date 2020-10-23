using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientDeleteCommandValidator : AbstractValidator<BankClientDeleteCommand>
	{
		public BankClientDeleteCommandValidator()
		{
			RuleFor(m => m.Id)
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}
