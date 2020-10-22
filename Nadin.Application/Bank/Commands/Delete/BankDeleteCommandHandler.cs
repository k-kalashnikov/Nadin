using Microsoft.EntityFrameworkCore;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.Bank.Commands
{
	public class BankDeleteCommandHandler : BaseHandler<BankDeleteCommand, bool>
	{
		public BankDeleteCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<bool> Handle(BankDeleteCommand request, CancellationToken cancellationToken)
		{
			var bank = await ContextDb.Banks.FirstOrDefaultAsync(m => m.Id.Equals(request.Id));

			if (bank is null) 
			{
				return false;
			}

			ContextDb.Banks.Remove(bank);
			await ContextDb.SaveChangesAsync();

			return true;

		}
	}
}
