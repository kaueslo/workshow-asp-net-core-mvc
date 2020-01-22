using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models.enums;

namespace VendasWebMVC.Models
{
	public class RegistroVendedor
	{
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public double Quantia { get; set; }
		public statusVenda status { get; set; }
		public Vendedor Vendedor { get; set; }

		public RegistroVendedor()
		{

		}

		public RegistroVendedor(int id, DateTime data, double quantia, statusVenda status, Vendedor vendedor)
		{
			Id = id;
			Data = data;
			Quantia = quantia;
			this.status = status;
			Vendedor = vendedor;
		}
	}
}
