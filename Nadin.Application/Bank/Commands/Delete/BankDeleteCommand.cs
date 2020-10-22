using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Commands
{
	public class BankDeleteCommand : IRequest<bool>
	{
		public Guid Id { get; set; }
	}
}
