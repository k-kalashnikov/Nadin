using Nadin.Application.Common;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientCreateCommandHandler : BaseHandler<BankClientCreateCommand, Guid?>
	{
		public BankClientCreateCommandHandler(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public override async Task<Guid?> Handle(BankClientCreateCommand request, CancellationToken cancellationToken)
		{
			var model = new Domains.Entities.BankClient()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				SecondName = request.SecondName
			};

			await ContextDb.BankClients.AddAsync(model, cancellationToken);
			await ContextDb.SaveChangesAsync();

			return model.Id;
		}
	}
}
