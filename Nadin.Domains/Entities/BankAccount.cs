using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Domains.Entities
{
	public class BankAccount
	{
		public Guid Id { get; set; }

		public string AccountId { get; set; }

		public BankAccountType AccountType { get; set; }

		public Guid BankId { get; set; }

		public Guid BankClientId { get; set; }

		public Bank Bank { get; set; }

		public BankClient BankClient { get; set; }

		public ICollection<Transaction> Output { get; set; }

		public ICollection<Transaction> Input { get; set; }
	}
}
