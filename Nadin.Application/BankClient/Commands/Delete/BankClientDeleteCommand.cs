using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Commands
{
	public class BankClientDeleteCommand : IRequest<bool>
	{
		public Guid Id { get; set; }
	}
}
