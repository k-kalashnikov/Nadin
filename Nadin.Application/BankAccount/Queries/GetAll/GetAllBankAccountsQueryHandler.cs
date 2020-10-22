using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankAccount.Queries
{
	public class GetAllBankAccountsQueryHandler : BaseHandler<GetAllBankAccountsQuery, IEnumerable<BankAccountDto>>
	{
		public GetAllBankAccountsQueryHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<IEnumerable<BankAccountDto>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
		{
			var models = await ContextDb.BankAccounts
				.Include(m => m.Bank)
				.Include(m => m.BankClient)
				.ToListAsync(cancellationToken);

			if (models is null) 
			{
				throw new Exception("GetAllBanksQueryHandler - Banks not found");
			}

			return models.Select(m => new BankAccountDto()
			{
				Id = m.Id,
				AccountId = m.AccountId,
				AccountType = m.AccountType,
				Balance = m.Balance,
				Bank = new BankDto() 
				{
					Id = m.Bank.Id,
					InputFee = m.Bank.InputFee,
					OutputFee = m.Bank.OutputFee,
					Name = m.Bank.Name,
					Accounts = null
				},
				BankClient = new BankClient.Models.BankClientDto() 
				{
					FirstName = m.BankClient.FirstName,
					LastName = m.BankClient.LastName,
					SecondName = m.BankClient.SecondName,
					Id = m.BankClient.Id,
					Accounts = null
				},
				Input = null,
				Output = null
			});
        }
	}
}
