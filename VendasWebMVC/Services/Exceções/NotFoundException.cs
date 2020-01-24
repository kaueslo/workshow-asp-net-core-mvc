using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMVC.Services.Exceções
{
	public class NotFoundException : ApplicationException
	{
		public NotFoundException(string mensagem) : base(mensagem)
		{
		}
	}
}
