using Nadin.Application.Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.User.Models
{
	public class UserDto
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public ICollection<TransactionDto> Transactions { get; set; }
	}
}
