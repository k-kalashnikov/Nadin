using Nadin.Application.BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Models
{
	public class BankClientDto
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string LastName { get; set; }

		public ICollection<BankAccountDto> Accounts { get; set; }
	}
}
