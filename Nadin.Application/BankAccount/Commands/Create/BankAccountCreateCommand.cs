using MediatR;
using Nadin.Application.BankClient.Models;
using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountCreateCommand : IRequest<Guid?>
	{
		public BankAccountType AccountType { get; set; }

		public Guid BankClientId{ get; set; }

		public Guid BankId{ get; set; }
	}
}
