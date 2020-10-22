using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nadin.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Persistence
{
	public class ApplicationDbContext : IdentityDbContext<Nadin.Domains.Entities.User, IdentityRole<Guid>, Guid>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Nadin.Domains.Entities.Bank> Banks { get; set; }

		public DbSet<Nadin.Domains.Entities.BankAccount> BankAccounts { get; set; }

		public DbSet<Nadin.Domains.Entities.BankClient> BankClients { get; set; }

		public DbSet<Nadin.Domains.Entities.Transaction> Transactions{ get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<BankAccount>()
				.HasMany(m => m.Input)
				.WithOne(m => m.To)
				.HasForeignKey(m => m.ToId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<BankAccount>()
				.HasMany(m => m.Output)
				.WithOne(m => m.From)
				.HasForeignKey(m => m.FromId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
