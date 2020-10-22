using MediatR;
using Nadin.Application.Bank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Application.Bank.Queries
{
	public class GetAllBanksQuery : IRequest<IEnumerable<BankDto>>
	{

	}
}
