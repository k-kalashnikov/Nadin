using Nadin.Application.BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Models
{
	public class BankDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public double InputFee { get; set; }

		public double OutputFee { get; set; }

		public ICollection<BankAccountDto> Accounts { get; set; }
	}
}
