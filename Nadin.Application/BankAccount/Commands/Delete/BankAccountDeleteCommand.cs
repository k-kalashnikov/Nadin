using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Commands
{
	public class BankAccountDeleteCommand : IRequest<bool>
	{
		public Guid Id { get; set; }
	}
}
