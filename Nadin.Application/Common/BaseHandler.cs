using MediatR;
using Nadin.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nadin.Application.Common
{
	public abstract class BaseHandler<TQ, TM> : IRequestHandler<TQ, TM> where TQ : IRequest<TM>
	{
		protected ApplicationDbContext ContextDb { get; }

		protected BaseHandler(ApplicationDbContext applicationDbContext)
		{
			ContextDb = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
		}

		public abstract Task<TM> Handle(TQ request, CancellationToken cancellationToken);

	}
}
