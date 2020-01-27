using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Services
{
	public class ServicoDepartamento
	{
		private readonly VendasWebMVCContext _context;

		public ServicoDepartamento(VendasWebMVCContext context)
		{
			_context = context;
		}

		public async Task <List<Departamento>> AcharTodosAsync()
		{
			return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
		}
	}
}
