﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.CQRS.Queries
{
	public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
	{
		Task<TResult> HandleAsync(TQuery query);
	}
}
