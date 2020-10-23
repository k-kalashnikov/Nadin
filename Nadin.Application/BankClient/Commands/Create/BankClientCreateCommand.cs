using MediatR;
using Nadin.Application.BankClient.Models;
using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientCreateCommand : IRequest<Guid?>
	{
		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string LastName { get; set; }
	}
}
