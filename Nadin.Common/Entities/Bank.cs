using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Common.Entities
{
	public class Bank
	{
		public string Name { get; set; }

		public ICollection<BankAccount> Accounts { get; set; }

		public ICollection<BankClient> Clients { get; set; }


	}
}
