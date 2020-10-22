using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Commands
{

	public class BankUpdateCommandValidator : AbstractValidator<BankUpdateCommand>
	{
		public BankUpdateCommandValidator()
		{
			RuleFor(m => m.Id)
				.NotNull()
				.NotEqual(Guid.Empty);
			RuleFor(x => x.Name).NotNull().NotEmpty();
			RuleFor(x => x.InputFee).NotNull();
			RuleFor(x => x.OutputFee).NotNull();
		}
	}
}
