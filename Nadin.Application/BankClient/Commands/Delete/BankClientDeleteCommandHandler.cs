using Microsoft.EntityFrameworkCore;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientDeleteCommandHandler : BaseHandler<BankClientDeleteCommand, bool>
	{
		public BankClientDeleteCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<bool> Handle(BankClientDeleteCommand request, CancellationToken cancellationToken)
		{
			var model = await ContextDb.BankClients.FirstOrDefaultAsync(m => m.Id.Equals(request.Id));

			if (model is null) 
			{
				return false;
			}

			ContextDb.BankClients.Remove(model);
			await ContextDb.SaveChangesAsync();

			return true;

		}
	}
}
