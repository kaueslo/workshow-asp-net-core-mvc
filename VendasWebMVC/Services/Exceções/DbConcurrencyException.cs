﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMVC.Services.Exceções
{
	public class DbConcurrencyException : ApplicationException
	{
		public DbConcurrencyException(string mensagem) : base(mensagem)
		{

		}
	}
}
