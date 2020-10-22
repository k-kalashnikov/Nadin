using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.Bank.Commands
{
	public class BankUpdateCommandHandler : BaseHandler<BankUpdateCommand, BankDto>
	{
		public BankUpdateCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<BankDto> Handle(BankUpdateCommand request, CancellationToken cancellationToken)
		{
			var bank = await ContextDb.Banks.FirstOrDefaultAsync(m => m.Id.Equals(request.Id));

			if (bank is null) 
			{
				throw new Exception($"BankUpdateCommandHandler - bank not found");
			}

			bank.InputFee = request.InputFee;
			bank.OutputFee = request.OutputFee;
			bank.Name = request.Name;

			ContextDb.Banks.Update(bank);
			await ContextDb.SaveChangesAsync();

			return new BankDto() {
				Id = bank.Id,
				Name = bank.Name,
				InputFee = bank.InputFee,
				OutputFee = bank.OutputFee
			};
		}
	}
}
