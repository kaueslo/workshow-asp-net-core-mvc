using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace VendasWebMVC.Models
{
	public class Vendedor
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public DateTime dtAniversario { get; set; }
		public double Salario { get; set; }
		public Departamento Departamento { get; set; }
		public int DepartamentoId { get; set; }
		public ICollection<RegistroVendedor> Vendas { get; set; } = new List<RegistroVendedor>();

		public Vendedor()
		{

		}

		public Vendedor(int id, string nome, string email, DateTime dtAniversario, double salario, Departamento departamento)
		{
			Id = id;
			Nome = nome;
			Email = email;
			this.dtAniversario = dtAniversario;
			Salario = salario;
			Departamento = departamento;
		}

		public void AddVendas(RegistroVendedor rv)
		{
			Vendas.Add(rv);
		}

		public void RemoveVendar(RegistroVendedor rv)
		{
			Vendas.Remove(rv);
		}

		public double TotalVendas(DateTime inicio, DateTime final)
		{
			return Vendas.Where(rv => rv.Data >= inicio && rv.Data <= final).Sum(rv => rv.Quantia);
		}
	}
}
