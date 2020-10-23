using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.Bank.Queries
{
	public class GetByIdBankQueryHandler : BaseHandler<GetByIdBankQuery, BankDto>
	{
		public GetByIdBankQueryHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<BankDto> Handle(GetByIdBankQuery request, CancellationToken cancellationToken)
		{
			var model = await ContextDb.Banks
				.Include(m => m.Accounts)
				.FirstOrDefaultAsync(m => m.Id.Equals(request.Id));

			if (model is null) 
			{
				throw new Exception($"GetByIdBankQueryHandler bank with id = {request.Id} not found");
			}

			return new BankDto()
			{
				InputFee = model.InputFee,
				OutputFee = model.OutputFee,
				Id = model.Id,
				Name = model.Name,
				Accounts = model.Accounts.Select(m => new BankAccount.Models.BankAccountDto() {
					AccountId = m.AccountId,
					AccountType = m.AccountType,
					Balance = m.Balance,
					Id = m.Id,
					Bank = null,
					BankClient = null,
					Input = null,
					Output = null
				}).ToList()
			};
		}
	}
}
