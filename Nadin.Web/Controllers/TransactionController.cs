using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nadin.Application.User.Models;
using Nadin.Persistence;
using Nadin.Web.Models;

namespace Nadin.Web.Controllers
{
	[Authorize]
	public class TransactionController : Controller
	{
		private ApplicationDbContext Context { get; set; }
		private IMediator Mediator { get; set; }

		public TransactionController(ApplicationDbContext context, IMediator mediator)
		{
			Context = context;
			Mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ChouseBank(Guid fromId)
		{
			var result = await Mediator.Send(new Nadin.Application.Bank.Queries.GetAllBanksQuery());
			ViewBag.FromId = fromId;
			return View(result);
		}

		[HttpGet]
		public async Task<IActionResult> ChouseBankAccount(Guid fromId, Guid bankId)
		{
			var result = await Mediator.Send(new Nadin.Application.Bank.Queries.GetByIdBankQuery() {
				Id = bankId
			});
			ViewBag.FromId = fromId;
			return View(result);
		}

		[HttpGet]
		public IActionResult Send(Guid fromId, Guid toId)
		{
			var result = new TransactionCreateViewModel()
			{
				FromId = fromId,
				ToId = toId
			};
			return View(result);
		}

		[HttpPost]
		public async Task<IActionResult> Send(TransactionCreateViewModel model)
		{
			var command = new Nadin.Application.Transaction.Commands.TransactionCreateCommand()
			{
				FromId = model.FromId,
				Number = model.Number,
				ToId = model.ToId,
				UserId = (await Context.Users.FirstAsync(m => m.UserName.Equals(User.Identity.Name))).Id
			};

			var result = await Mediator.Send(command);
			result.User = await Context.Users
				.Select(m => new UserDto() {
					UserName = m.UserName,
					Id = m.Id,
					Transactions = null
				})
				.FirstAsync(m => m.UserName.Equals(User.Identity.Name));
			return View("Detail", result);
		}
	}
}
