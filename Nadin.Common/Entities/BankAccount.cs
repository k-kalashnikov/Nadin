using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Common.Entities
{
	public class BankAccount
	{
		public string AccountId { get; set; }

		public BankAccountType AccountType { get; set; }

		public Bank Bank { get; set; }

	}
}
