using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.CQRS.Queries
{
	public interface IQueryDispatcher
	{
		Task DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}
