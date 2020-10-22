using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nadin.Domains.Entities
{
	public class Bank
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public ICollection<BankAccount> Accounts { get; set; }

	}
}
