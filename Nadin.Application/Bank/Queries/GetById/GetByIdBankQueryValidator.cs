using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Queries
{
	public class GetByIdBankQueryValidator : AbstractValidator<GetByIdBankQuery>
	{
		public GetByIdBankQueryValidator() 
		{
			RuleFor(m => m.Id)
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}
