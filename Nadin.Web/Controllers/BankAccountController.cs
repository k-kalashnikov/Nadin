using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nadin.Application.Bank.Models;
using Nadin.Application.BankClient.Models;
using Nadin.Persistence;
using Nadin.Web.Models;

namespace Nadin.Web.Controllers
{
	[Authorize]
	public class BankAccountController : Controller
	{
		private ApplicationDbContext Context { get; set; }
		private IMediator Mediator { get; set; }

		public BankAccountController(ApplicationDbContext context, IMediator mediator)
		{
			Context = context;
			Mediator = mediator;
		}

        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new Nadin.Application.BankAccount.Queries.GetAllBankAccountsQuery());
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new BankAccountCreateViewModel()
            {
                PosibleBankClients = await Context.BankClients.Select(m => new BankClientDto()
                {
                    FirstName = m.FirstName,
                    Accounts = null,
                    Id = m.Id,
                    LastName = m.LastName,
                    SecondName = m.SecondName
                }).ToListAsync(),
                PosibleBanks = await Context.Banks.Select(m => new BankDto()
                {
                    InputFee = m.InputFee,
                    OutputFee = m.OutputFee,
                    Accounts = null,
                    Id = m.Id,
                    Name = m.Name
                }).ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankAccountCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new Nadin.Application.BankAccount.Commands.BankAccountCreateCommand()
                {
                    AccountType = model.AccountType,
                    BankClientId = model.BankClientId,
                    BankId = model.BankId
                };
                var result = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await Context.BankAccounts.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(new BankAccountUpdateViewModel()
            {
                AccountType = model.AccountType,
                BankClientId = model.BankClientId,
                BankId = model.BankId,
                Id = model.Id,
                PosibleBankClients = await Context.BankClients.Select(m => new BankClientDto()
                {
                    FirstName = m.FirstName,
                    Accounts = null,
                    Id = m.Id,
                    LastName = m.LastName,
                    SecondName = m.SecondName
                }).ToListAsync(),
                PosibleBanks = await Context.Banks.Select(m => new BankDto()
                {
                    InputFee = m.InputFee,
                    OutputFee = m.OutputFee,
                    Accounts = null,
                    Id = m.Id,
                    Name = m.Name
                }).ToListAsync()
            }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankAccountUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new Nadin.Application.BankAccount.Commands.BankAccountUpdateCommand()
                {

                };

                var result = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            model.PosibleBankClients = await Context.BankClients.Select(m => new BankClientDto()
            {
                FirstName = m.FirstName,
                Accounts = null,
                Id = m.Id,
                LastName = m.LastName,
                SecondName = m.SecondName
            }).ToListAsync();
            model.PosibleBanks = await Context.Banks.Select(m => new BankDto()
            {
                InputFee = m.InputFee,
                OutputFee = m.OutputFee,
                Accounts = null,
                Id = m.Id,
                Name = m.Name
            }).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = new Nadin.Application.BankAccount.Commands.BankAccountDeleteCommand()
            {
                Id = id.Value,
            };

            var result = await Mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
