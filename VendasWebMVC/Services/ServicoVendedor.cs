using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Services.Exceções;

namespace VendasWebMVC.Services
{
	public class ServicoVendedor
	{
		private readonly VendasWebMVCContext _context;

		public ServicoVendedor(VendasWebMVCContext context)
		{
			_context = context;
		}

		public List<Vendedor> AcharTodos()
		{
			return _context.Vendedor.ToList();
		}

		public void Inserir(Vendedor obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
		}

		public Vendedor AcharPorId(int id)
		{
			return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
		}

		public void Remover(int id)
		{
			var obj = _context.Vendedor.Find(id);
			_context.Vendedor.Remove(obj);
			_context.SaveChanges();
		}

		public void Atualizar(Vendedor obj)
		{
			if (!_context.Vendedor.Any(x => x.Id == obj.Id))
			{
				throw new NotFoundException("Id não encontrado");
			}
			try
			{
				_context.Update(obj);
				_context.SaveChanges();

			}
			catch (DbUpdateConcurrencyException e)
			{
				throw new DbConcurrencyException(e.Message);
			}

		}
	}
}
