using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Commands
{

	public class BankClientUpdateCommandValidator : AbstractValidator<BankClientUpdateCommand>
	{
		public BankClientUpdateCommandValidator()
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

			RuleFor(x => x.Id)
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}
