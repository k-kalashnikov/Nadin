using MediatR;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using Nadin.Application.BankClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankClient.Queries
{
	public class GetAllBankClientQuery : IRequest<IEnumerable<BankClientDto>>
	{

	}
}
