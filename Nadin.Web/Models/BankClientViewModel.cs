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
	public class BankClientCreateViewModel
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string SecondName { get; set; }

		[Required]
		public string LastName { get; set; }
	}

	public class BankClientUpdateViewModel
	{

		[Required]
		public Guid Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string SecondName { get; set; }

		[Required]
		public string LastName { get; set; }


	}
}
