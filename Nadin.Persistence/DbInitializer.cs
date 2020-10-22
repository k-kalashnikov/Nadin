using Microsoft.AspNetCore.Identity;
using Nadin.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin.Persistence
{
    public class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<User> userManager)
        {
            if (context.Users.FirstOrDefault(m => m.Email.Equals("admin@admin.com")) == null) 
            {
                var admin = new User()
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com"
                };

                await userManager.CreateAsync(admin, "AllRight73!");
            }


            var bankList = new List<Bank>()
            {
                new Bank()
                {
                    Name = "Сбербанк",
                    InputFee = 0,
                    OutputFee = 1
                },
                new Bank()
                {
                    Name = "Втб",
                    InputFee = 0,
                    OutputFee = 2
                },
                new Bank()
                {
                    Name = "Альфабанк",
                    InputFee = 1,
                    OutputFee = 2.5
                },
            };

			if (!context.Banks.ToList().Any()) 
            {
                foreach (var item in bankList)
                {
                    context.Banks.Add(item);
                    Console.WriteLine($"Create bank {item.Name} with id {item.Id} added");
                }

                await context.SaveChangesAsync();
            }


        }
    }
}
