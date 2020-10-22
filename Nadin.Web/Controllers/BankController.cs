using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nadin.Domains.Entities;
using Nadin.Persistence;
using Nadin.Web.Models;

namespace Nadin.Web.Controllers
{
    [Authorize]
    public class BankController : Controller
    {
        private ApplicationDbContext Context { get; set; }
        private IMediator Mediator { get; set; }

        public BankController(ApplicationDbContext context, IMediator mediator)
        {
            Context = context;
            Mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new Nadin.Application.Bank.Queries.GetAllBanksQuery());
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankCreateViewModel bank)
        {
            if (ModelState.IsValid)
            {
                var command = new Nadin.Application.Bank.Commands.BankCreateCommand() {
                    InputFee = bank.InputFee,
                    OutputFee = bank.OutputFee,
                    Name = bank.Name
                };
                var result = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(bank);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await Context.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }
            return View(new BankUpdateViewModel() {
                Id = bank.Id,
                InputFee = bank.InputFee,
                OutputFee = bank.OutputFee,
                Name = bank.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankUpdateViewModel bank)
        {
            if (ModelState.IsValid)
            {
                var command = new Nadin.Application.Bank.Commands.BankUpdateCommand()
                {
                    Id = bank.Id,
                    InputFee = bank.InputFee,
                    OutputFee = bank.OutputFee,
                    Name = bank.Name
                };
                var result = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(bank);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = new Nadin.Application.Bank.Commands.BankDeleteCommand()
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
