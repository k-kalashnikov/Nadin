using MediatR;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using Nadin.Application.BankClient.Models;
using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientUpdateCommand : IRequest<BankClientDto>
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string LastName { get; set; }
	}
}
