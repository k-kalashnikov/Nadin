using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Common.Entities
{
	public class Transaction
	{
		public BankAccount From { get; set; }

		public BankAccount To { get; set; }

		public long Number { get; set; }

		public long BankFee { get; set; }

		public long SystemFee { get; set; }

		public DateTime TransactionDate { get; set; }

		public User User { get; set; }
	}
}
