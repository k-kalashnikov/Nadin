using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountUpdateCommandHandler : BaseHandler<BankAccountUpdateCommand, BankAccountDto>
	{
		public BankAccountUpdateCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<BankAccountDto> Handle(BankAccountUpdateCommand request, CancellationToken cancellationToken)
		{
			var model = await ContextDb.BankAccounts.FirstOrDefaultAsync(m => m.Id.Equals(request.Id));

			Console.WriteLine(request.Id);

			if (model is null) 
			{
				throw new Exception($"BankAccountUpdateCommandHandler - bankAccount not found");
			}

			model.BankClientId = request.BankClientId;
			model.BankId = request.BankId;
			model.AccountType = request.AccountType;
			model.Balance = request.Balance;

			ContextDb.BankAccounts.Update(model);
			await ContextDb.SaveChangesAsync();

			return new BankAccountDto() {
				AccountType = request.AccountType
		};
		}
	}
}
