using MediatR;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.BankAccount.Queries
{
	public class GetAllBankAccountsQuery : IRequest<IEnumerable<BankAccountDto>>
	{

	}
}
