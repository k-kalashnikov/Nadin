using MediatR;
using Microsoft.EntityFrameworkCore;
using Nadin.Application.Common;
using Nadin.Application.Transaction.Models;
using Nadin.Common.Enums;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.Transaction.Commands
{
	public class TransactionCreateCommandHandler : BaseHandler<TransactionCreateCommand, TransactionDto>
	{

		private Dictionary<BankAccountType, Dictionary<BankAccountType, double>> SystemFee { get; set; } = new Dictionary<BankAccountType, Dictionary<BankAccountType, double>>()
		{
			{ 
				BankAccountType.Legal, 
				new Dictionary<BankAccountType, double> {
					{ BankAccountType.Legal, 3},
					{ BankAccountType.Physical, 2},
					{ BankAccountType.Unknown, 4},
				}
			},
			{
				BankAccountType.Physical,
				new Dictionary<BankAccountType, double> {
					{ BankAccountType.Legal, 0},
					{ BankAccountType.Physical, 0},
					{ BankAccountType.Unknown, 0},
				}
			},
			{
				BankAccountType.Unknown,
				new Dictionary<BankAccountType, double> {
					{ BankAccountType.Legal, 6},
					{ BankAccountType.Physical, 4},
					{ BankAccountType.Unknown, 6},
				}
			},
		};

		private IMediator Mediator { get; set; }


		public TransactionCreateCommandHandler(ApplicationDbContext applicationDbContext, IMediator mediator) : base(applicationDbContext)
		{
			Mediator = mediator;
		}

		public override async Task<TransactionDto> Handle(TransactionCreateCommand request, CancellationToken cancellationToken)
		{
			var fromAccount = await ContextDb
				.BankAccounts
				.Include(m => m.Bank)
				.FirstOrDefaultAsync(m => m.Id.Equals(request.FromId));

			if (fromAccount is null) 
			{
				throw new Exception($"TransactionCreateCommandHandler - not found account with id = {request.FromId}");
			}

			var toAccount = await ContextDb
				.BankAccounts
				.Include(m => m.Bank)
				.FirstOrDefaultAsync(m => m.Id.Equals(request.ToId));

			if (toAccount is null) 
			{
				throw new Exception($"TransactionCreateCommandHandler - not found account with id = {request.ToId}");
			}

			double number = request.Number;
			double numberWithFee = (double)request.Number
				+ ((request.Number * SystemFee[fromAccount.AccountType][toAccount.AccountType]) / 100)
				+ ((request.Number * ((fromAccount.BankId.Equals(toAccount.BankId)) ? fromAccount.Bank.InputFee : fromAccount.Bank.OutputFee)) / 100);

			if ((decimal)numberWithFee > fromAccount.Balance)
			{
				throw new Exception("NEED MORE GOLD");
			}

			var commandFromUpdate = new Nadin.Application.BankAccount.Commands.BankAccountUpdateCommand()
			{
				AccountType = fromAccount.AccountType,
				Balance = fromAccount.Balance - (decimal)numberWithFee,
				BankClientId = fromAccount.BankClientId,
				BankId = fromAccount.BankId,
				Id = fromAccount.Id
			};

			await Mediator.Send(commandFromUpdate);

			var commandToUpdate = new Nadin.Application.BankAccount.Commands.BankAccountUpdateCommand()
			{
				AccountType = toAccount.AccountType,
				Balance = toAccount.Balance + (decimal)number,
				BankClientId = toAccount.BankClientId,
				BankId = toAccount.BankId,
				Id = toAccount.Id
			};

			await Mediator.Send(commandToUpdate);

			var transaction = new Nadin.Domains.Entities.Transaction()
			{
				FromId = fromAccount.Id,
				ToId = toAccount.Id,
				BankFee = ((request.Number * ((fromAccount.BankId.Equals(toAccount.BankId)) ? fromAccount.Bank.InputFee : fromAccount.Bank.OutputFee)) / 100),
				SystemFee = ((request.Number * SystemFee[fromAccount.AccountType][toAccount.AccountType]) / 100),
				Number = number,
				TransactionDate = DateTime.Now,
				UserId = request.UserId
			};

			await ContextDb.Transactions.AddAsync(transaction);
			await ContextDb.SaveChangesAsync();

			return new TransactionDto()
			{
				From = new BankAccount.Models.BankAccountDto() 
				{
					AccountId = fromAccount.AccountId,
					AccountType = fromAccount.AccountType,
					Balance = fromAccount.Balance - (decimal)numberWithFee,
					Bank = null,
					BankClient = null,
					Id = fromAccount.Id,
					Input = null,
					Output = null
				},
				To = new BankAccount.Models.BankAccountDto()
				{
					AccountId = toAccount.AccountId,
					AccountType = toAccount.AccountType,
					Balance = toAccount.Balance + (decimal)number,
					Bank = null,
					BankClient = null,
					Id = toAccount.Id,
					Input = null,
					Output = null
				},
				BankFee = transaction.BankFee,
				SystemFee = transaction.SystemFee,
				Id = transaction.Id,
				Number = transaction.Number,
				TransactionDate = transaction.TransactionDate,
				User = null
			};
		}


	}
}
