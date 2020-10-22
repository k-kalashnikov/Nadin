using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Domains.Entities
{
	public class BankClient
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string LastName { get; set; }

		public ICollection<BankAccount> Accounts { get; set; }
	}
}
