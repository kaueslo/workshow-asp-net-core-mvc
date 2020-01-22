using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using VendasWebMVC.Models.enums;

namespace VendasWebMVC.Data
{
	public class Seedingservice
	{
		private VendasWebMVCContext _context;

		public Seedingservice(VendasWebMVCContext context)
		{
			_context = context;
		}

		public void Seed()
		{
			if(_context.Departamento.Any() || 
				_context.Vendedor.Any() ||
				_context.RegistroVendedor.Any())
			{
				//Banco de dados já foi populado
				return;
			}

			Departamento d1 = new Departamento(1, "Games");
			Departamento d2 = new Departamento(2, "Eletrônicos");
			Departamento d3 = new Departamento(3, "Livros");
			Departamento d4 = new Departamento(4, "Cds");

			Vendedor v1 = new Vendedor(1, "Japonês", "japinha@japa.com", new DateTime(1997, 12, 05), 1600.0, d1);
			Vendedor v2 = new Vendedor(2, "Marcelo", "Marcelo@hotmail.com", new DateTime(1970, 12, 05), 1700.0, d2);
			Vendedor v3 = new Vendedor(3, "Kaluane", "kaluane@hotmail.com", new DateTime(1992, 05, 25), 2200.0, d3);
			Vendedor v4 = new Vendedor(4, "Christyano", "Christyano@gmail.com", new DateTime(1991, 12, 05), 1200.0, d2);
			Vendedor v5 = new Vendedor(5, "Kauê", "Kauê@hotmail.com", new DateTime(1998, 08, 17), 1200.0, d1);
			Vendedor v6 = new Vendedor(6, "Adriana", "Adriana@gmail.com", new DateTime(1970, 12, 31), 2500.0, d4);

			RegistroVendedor r1 = new RegistroVendedor(1, new DateTime(2018, 09, 25), 11000.0, statusVenda.Faturado, v1);
			RegistroVendedor r2 = new RegistroVendedor(2, new DateTime(2019, 09, 25), 9000.0, statusVenda.Faturado, v2);
			RegistroVendedor r3 = new RegistroVendedor(3, new DateTime(2018, 09, 25), 1000.0, statusVenda.Faturado, v3);
			RegistroVendedor r4 = new RegistroVendedor(4, new DateTime(2018, 09, 25), 8000.0, statusVenda.Faturado, v4);
			RegistroVendedor r5 = new RegistroVendedor(5, new DateTime(2018, 09, 25), 5000.0, statusVenda.Faturado, v5);
			RegistroVendedor r6 = new RegistroVendedor(6, new DateTime(2018, 09, 25), 30000.0, statusVenda.Faturado, v6);
			RegistroVendedor r7 = new RegistroVendedor(7, new DateTime(2018, 09, 25), 11000.0, statusVenda.Faturado, v1);
			RegistroVendedor r8 = new RegistroVendedor(8, new DateTime(2018, 09, 25), 30000.0, statusVenda.Faturado, v6);
			RegistroVendedor r9 = new RegistroVendedor(9, new DateTime(2018, 09, 25), 3000.0, statusVenda.Faturado, v2);
			RegistroVendedor r10 = new RegistroVendedor(10, new DateTime(2018, 09, 25), 30000.0, statusVenda.Faturado, v6);


			_context.Departamento.AddRange(d1, d2, d3, d4);

			_context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);

			_context.RegistroVendedor.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

			_context.SaveChanges();
		}
	}
}
