using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
	public class ServicoVendedor
	{
		private readonly VendasWebMVCContext _context;

		public ServicoVendedor (VendasWebMVCContext context)
		{
			_context = context;
		}

		public List<Vendedor> AcharTodos()
		{
			return _context.Vendedor.ToList();
		}

		public void Inserir(Vendedor obj)
		{
			obj.Departamento = _context.Departamento.First();
			_context.Add(obj);
			_context.SaveChanges();
		}

	}
}
