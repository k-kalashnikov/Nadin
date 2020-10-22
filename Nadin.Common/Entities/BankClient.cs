using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Common.Entities
{
	public class BankClient
	{
		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string LastName { get; set; }

		public ICollection<BankAccount> Accounts { get; set; }

		public ICollection<Bank> Banks { get; set; }
	}
}
