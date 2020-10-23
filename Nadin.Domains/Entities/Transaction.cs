using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Domains.Entities
{
	public class Transaction
	{
		public Guid Id { get; set; }

		public double Number { get; set; }

		public double BankFee { get; set; }

		public double SystemFee { get; set; }

		public DateTime TransactionDate { get; set; }

		public Guid UserId { get; set; }

		public Guid FromId { get; set; }

		public Guid ToId { get; set; }

		public User User { get; set; }

		public BankAccount From { get; set; }

		public BankAccount To { get; set; }
	}
}
