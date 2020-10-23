using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountCreateCommandHandler : BaseHandler<BankAccountCreateCommand, Guid?>
	{
		public BankAccountCreateCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<Guid?> Handle(BankAccountCreateCommand request, CancellationToken cancellationToken)
		{
			var bankAccount = new Domains.Entities.BankAccount()
			{
				AccountId = Guid.NewGuid(),
				AccountType = request.AccountType,
				BankClientId = request.BankClientId,
				BankId = request.BankId
			};

			await ContextDb.BankAccounts.AddAsync(bankAccount, cancellationToken);
			await ContextDb.SaveChangesAsync();

			return bankAccount.Id;
		}
	}
}
