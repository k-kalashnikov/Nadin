using MediatR;
using Nadin.Application.Bank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Commands
{
	public class BankUpdateCommand : IRequest<BankDto>
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public double InputFee { get; set; }

		public double OutputFee { get; set; }
	}
}
