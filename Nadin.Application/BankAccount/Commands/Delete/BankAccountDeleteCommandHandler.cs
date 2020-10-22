using Microsoft.EntityFrameworkCore;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountDeleteCommandHandler : BaseHandler<BankAccountDeleteCommand, bool>
	{
		public BankAccountDeleteCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<bool> Handle(BankAccountDeleteCommand request, CancellationToken cancellationToken)
		{
			var bankAccount = await ContextDb.BankAccounts.FirstOrDefaultAsync(m => m.Id.Equals(request.Id));

			if (bankAccount is null) 
			{
				return false;
			}

			ContextDb.BankAccounts.Remove(bankAccount);
			await ContextDb.SaveChangesAsync();

			return true;

		}
	}
}
