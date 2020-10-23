using Nadin.Application.Bank.Models;
using Nadin.Application.BankClient.Models;
using Nadin.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadin.Web.Models
{
	public class BankAccountCreateViewModel
	{
		public BankAccountCreateViewModel() 
		{
			PosibleBanks = new List<BankDto>();
			PosibleBankClients = new List<BankClientDto>();
		}

		[Required]
		public BankAccountType AccountType { get; set; }

		[Required]
		public decimal Balance{ get; set; }

		[Required]
		public Guid BankClientId { get; set; }

		[Required]
		public Guid BankId { get; set; }

		public ICollection<BankDto> PosibleBanks { get; set; }

		public ICollection<BankClientDto> PosibleBankClients { get; set; }
	}

	public class BankAccountUpdateViewModel
	{
		public BankAccountUpdateViewModel()
		{
			PosibleBanks = new List<BankDto>();
			PosibleBankClients = new List<BankClientDto>();
		}

		[Required]
		public Guid Id { get; set; }

		[Required]
		public BankAccountType AccountType { get; set; }

		[Required]
		public Guid BankClientId { get; set; }

		[Required]
		public decimal Balance { get; set; }

		[Required]
		public Guid BankId { get; set; }

		public ICollection<BankDto> PosibleBanks { get; set; }

		public ICollection<BankClientDto> PosibleBankClients { get; set; }

	}
}
