using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadin.Web.Models
{
	public class TransactionCreateViewModel
	{
		[Required]
		public long Number { get; set; }

		[Required]
		public Guid FromId { get; set; }

		[Required]
		public Guid ToId { get; set; }

		public Guid UserId { get; set; }
	}
}
