using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadin.Web.Models
{
	public class BankCreateViewModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public double InputFee { get; set; }

		[Required]
		public double OutputFee { get; set; }
	}

	public class BankUpdateViewModel
	{
		[Required]
		public Guid Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public double InputFee { get; set; }

		[Required]
		public double OutputFee { get; set; }
	}
}
