using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using Nadin.Application.BankClient.Models;
using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientUpdateCommandHandler : BaseHandler<BankClientUpdateCommand, BankClientDto>
	{
		public BankClientUpdateCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<BankClientDto> Handle(BankClientUpdateCommand request, CancellationToken cancellationToken)
		{
			var model = await ContextDb.BankClients.FirstOrDefaultAsync(m => m.Id.Equals(request.Id));

			if (model is null) 
			{
				throw new Exception($"BankClientUpdateCommandHandler - bankClient not found");
			}

			model.FirstName = request.FirstName;
			model.LastName = request.LastName;
			model.SecondName = request.SecondName;

			ContextDb.BankClients.Update(model);
			await ContextDb.SaveChangesAsync();

			return new BankClientDto() {
				Id = request.Id,
				FirstName = request.FirstName,
				LastName = request.LastName,
				SecondName = request.SecondName,
			};
		}
	}
}
