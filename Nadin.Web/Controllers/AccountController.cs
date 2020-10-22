using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Nadin.Web.Models;

namespace Nadin.Web.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private SignInManager<Nadin.Domains.Entities.User> SignInManager { get; set; }

		public AccountController(SignInManager<Nadin.Domains.Entities.User> signInManager) 
		{
			SignInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

			return BadRequest(ModelState);
        }

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await SignInManager.SignOutAsync();
			return LocalRedirect("/Account/Login");
		}
	}
}
