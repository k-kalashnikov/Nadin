using Nadin.Application.BankAccount.Models;
using Nadin.Application.User.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Transaction.Models
{
	public class TransactionDto
	{
		public Guid Id { get; set; }

		public double Number { get; set; }

		public double BankFee { get; set; }

		public double SystemFee { get; set; }

		public DateTime TransactionDate { get; set; }

		public UserDto User { get; set; }

		public BankAccountDto From { get; set; }

		public BankAccountDto To { get; set; }
	}
}
