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

		public async Task <List<Vendedor>> AcharTodosAsync()
		{
			return await _context.Vendedor.ToListAsync();
		}

		public async Task InserirAsync(Vendedor obj)
		{
			_context.Add(obj);
			await _context.SaveChangesAsync();
		}

		public async Task<Vendedor> AcharPorIdAsync(int id)
		{
			return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
		}

		public async Task RemoverAsync(int id)
		{
			var obj = await _context.Vendedor.FindAsync(id);
			_context.Vendedor.Remove(obj);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizarAsync(Vendedor obj)
		{
			bool temId = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);

			if (!temId)
			{
				throw new NotFoundException("Id não encontrado");
			}
			try
			{
				_context.Update(obj);
				await _context.SaveChangesAsync();

			}
			catch (DbUpdateConcurrencyException e)
			{
				throw new DbConcurrencyException(e.Message);
			}

		}
	}
}
