using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Services
{
	public class ServicoRegistroVendas
	{
		private readonly VendasWebMVCContext _context;

		public ServicoRegistroVendas(VendasWebMVCContext context)
		{
			_context = context;
		}

		public async Task<List<RegistroVendedor>> AchePorDataAsync(DateTime? dtMin, DateTime? dtMax)
		{
			var resultado = from obj in _context.RegistroVendedor select obj;


			if (dtMin.HasValue)
			{
				resultado = resultado.Where(x => x.Data >= dtMin.Value);
			}

			if (dtMin.HasValue)
			{
				resultado = resultado.Where(x => x.Data <= dtMax.Value);
			}

			return await resultado
				.Include(x => x.Vendedor)
				.Include(x => x.Vendedor.Departamento)
				.OrderByDescending(x => x.Data)
				.ToListAsync();

		}

		public async Task<List<IGrouping<Departamento,RegistroVendedor>>> AchePorDataAgrupadaAsync(DateTime? dtMin, DateTime? dtMax)
		{
			var resultado = from obj in _context.RegistroVendedor select obj;


			if (dtMin.HasValue)
			{
				resultado = resultado.Where(x => x.Data >= dtMin.Value);
			}

			if (dtMin.HasValue)
			{
				resultado = resultado.Where(x => x.Data <= dtMax.Value);
			}

			return await resultado
				.Include(x => x.Vendedor)
				.Include(x => x.Vendedor.Departamento)
				.OrderByDescending(x => x.Data)
				.GroupBy(x => x.Vendedor.Departamento)
				.ToListAsync();

		}
	}
}
