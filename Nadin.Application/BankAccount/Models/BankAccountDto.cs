using Nadin.Application.Bank.Models;
using Nadin.Application.BankClient.Models;
using Nadin.Application.Transaction.Models;
using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Models
{
	public class BankAccountDto
	{
		public Guid Id { get; set; }

		public Guid AccountId { get; set; }

		public BankAccountType AccountType { get; set; }

		public decimal Balance { get; set; }

		public BankDto Bank { get; set; }

		public BankClientDto BankClient { get; set; }

		public ICollection<TransactionDto> Output { get; set; }

		public ICollection<TransactionDto> Input { get; set; }
	}
}
