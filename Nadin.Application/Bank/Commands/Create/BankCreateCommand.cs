using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Commands
{
	public class BankCreateCommand : IRequest<Guid?>
	{
		public string Name { get; set; }

		public double InputFee { get; set; }

		public double OutputFee { get; set; }
	}
}
