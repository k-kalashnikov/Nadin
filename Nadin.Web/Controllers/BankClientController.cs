using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nadin.Persistence;
using Nadin.Web.Models;

namespace Nadin.Web.Controllers
{
	[Authorize]
	public class BankClientController : Controller
	{

		private ApplicationDbContext Context { get; set; }
		private IMediator Mediator { get; set; }

		public BankClientController(ApplicationDbContext context, IMediator mediator) 
		{
			Context = context;
			Mediator = mediator;
		}

		public async Task<IActionResult> Index()
		{
			var result = await Mediator.Send(new Nadin.Application.BankClient.Queries.GetAllBankClientQuery());
			return View(result);
		}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankClientCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new Nadin.Application.BankClient.Commands.BankClientCreateCommand()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SecondName = model.SecondName
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

            var model = await Context.BankClients.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(new BankClientUpdateViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SecondName = model.SecondName
            }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankClientUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new Nadin.Application.BankClient.Commands.BankClientUpdateCommand()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SecondName = model.SecondName,
                    Id = model.Id
                };
                var result = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = new Nadin.Application.BankClient.Commands.BankClientDeleteCommand()
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
