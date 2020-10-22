using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.Bank.Commands
{
	public class BankCreateCommandHandler : BaseHandler<BankCreateCommand, Guid?>
	{
		public BankCreateCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<Guid?> Handle(BankCreateCommand request, CancellationToken cancellationToken)
		{
			var bank = new Domains.Entities.Bank()
			{
				InputFee = request.InputFee,
				OutputFee = request.OutputFee,
				Name = request.Name
			};

			await ContextDb.Banks.AddAsync(bank, cancellationToken);
			await ContextDb.SaveChangesAsync();

			return bank.Id;
		}
	}
}
