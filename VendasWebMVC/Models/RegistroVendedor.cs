using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models.enums;

namespace VendasWebMVC.Models
{
	public class RegistroVendedor
	{
		public int Id { get; set; }


		[DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
		public DateTime Data { get; set; }

		[DisplayFormat(DataFormatString ="{0:F2}")]
		public double Quantia { get; set; }
		public statusVenda Status { get; set; }
		public Vendedor Vendedor { get; set; }

		public RegistroVendedor()
		{

		}

		public RegistroVendedor(int id, DateTime data, double quantia, statusVenda status, Vendedor vendedor)
		{
			Id = id;
			Data = data;
			Quantia = quantia;
			Status = status;
			Vendedor = vendedor;
		}
	}
}
