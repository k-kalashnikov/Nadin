using MediatR;
using Nadin.Application.Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Transaction.Commands
{
	public class TransactionCreateCommand : IRequest<TransactionDto>
	{
		public long Number { get; set; }

		public Guid FromId { get; set; }

		public Guid ToId { get; set; }

		public Guid UserId { get; set; }

	}
}
