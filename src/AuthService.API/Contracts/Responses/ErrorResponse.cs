﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.API.Contracts.Responses
{
	public class ErrorResponse
	{
		public string Error { get; set; }
		public ErrorResponse(string error)
		{
			Error = error;
		}
	}
}
