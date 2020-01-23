using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
	public class ServicoDepartamento
	{
		private readonly VendasWebMVCContext _context;

		public ServicoDepartamento(VendasWebMVCContext context)
		{
			_context = context;
		}

		public List<Departamento> AcharTodos()
		{
			return _context.Departamento.OrderBy(x => x.Nome).ToList();
		}
	}
}
