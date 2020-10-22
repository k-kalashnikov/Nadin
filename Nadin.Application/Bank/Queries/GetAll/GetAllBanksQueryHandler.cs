using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.Bank.Queries
{
	public class GetAllBanksQueryHandler : BaseHandler<GetAllBanksQuery, IEnumerable<BankDto>>
	{
		public GetAllBanksQueryHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<IEnumerable<BankDto>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
		{
			var banks = await ContextDb.Banks
				.Include(m => m.Accounts)
				.ToListAsync(cancellationToken);

			if (banks is null) 
			{
				throw new Exception("GetAllBanksQueryHandler - Banks not found");
			}

			return banks.Select(m => new BankDto()
			{
				Id = m.Id,
				Accounts = (m.Accounts is null) ? null : m.Accounts.Select(a => new BankAccount.Models.BankAccountDto() {
					AccountId = a.AccountId,
					AccountType = a.AccountType,
					Bank = null,
					BankClient = null,
					Id = a.Id,
					Input = null,
					Output = null
				}).ToList(),
				InputFee = m.InputFee,
				OutputFee = m.OutputFee,
				Name = m.Name
			});
        }
	}
}
