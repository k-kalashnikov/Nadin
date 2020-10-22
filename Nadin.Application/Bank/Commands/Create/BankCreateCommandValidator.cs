using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Commands
{
	public class BankCreateCommandValidator : AbstractValidator<BankCreateCommand>
	{
		public BankCreateCommandValidator() 
		{
			RuleFor(x => x.Name).NotNull().NotEmpty();
			RuleFor(x => x.InputFee).NotNull();
			RuleFor(x => x.OutputFee).NotNull();
		}
	}
}
