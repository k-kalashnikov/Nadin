using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using Nadin.Application.BankClient.Models;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankClient.Queries
{
	public class GetAllBankClientQueryHandler : BaseHandler<GetAllBankClientQuery, IEnumerable<BankClientDto>>
	{
		public GetAllBankClientQueryHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<IEnumerable<BankClientDto>> Handle(GetAllBankClientQuery request, CancellationToken cancellationToken)
		{
			var models = await ContextDb.BankClients
				.Include(m => m.Accounts)
				.ToListAsync(cancellationToken);

			if (models is null) 
			{
				throw new Exception("GetAllBanksQueryHandler - Banks not found");
			}

			return models.Select(m => new BankClientDto()
			{
				Id = m.Id,
				FirstName = m.FirstName,
				Accounts = m.Accounts.Select(a => new BankAccountDto() {
					AccountId = a.AccountId,
					AccountType = a.AccountType,
					Balance = a.Balance,
					Id = a.Id,
					Bank = null,
					BankClient = null,
					Input = null,
					Output = null
				}).ToList(),
				LastName = m.LastName,
				SecondName = m.SecondName
			});;
        }
	}
}
