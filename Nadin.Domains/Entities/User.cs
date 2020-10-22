using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nadin.Domains.Entities
{
	public class User : IdentityUser<Guid>
	{
		ICollection<Transaction> Transactions { get; set; }
	}
}
