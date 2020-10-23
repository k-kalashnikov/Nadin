using MediatR;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountUpdateCommand : IRequest<BankAccountDto>
	{
		public Guid Id { get; set; }

		public BankAccountType AccountType { get; set; }

		public Guid BankClientId { get; set; }

		public Guid BankId { get; set; }

		public decimal Balance { get; set; }
	}
}
