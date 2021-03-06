﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace VendasWebMVC.Models
{
	public class Vendedor
	{
		public int Id { get; set; }


		[Required(ErrorMessage ="{0} é requerido")]
		[StringLength(60, MinimumLength = 3, ErrorMessage ="{0} Nome deve contrar em {2} e {1} caracteres")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "{0} é requerido")]
		[EmailAddress(ErrorMessage ="Coloque um e-mail válido")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "{0} é requerido")]
		[Display(Name = "Data de Aniversário")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
		public DateTime dtAniversario { get; set; }

		[DisplayFormat(DataFormatString ="{0:F2}")]

		[Required(ErrorMessage = "{0} é requerido")]
		[Range(100.0, 50000.0, ErrorMessage = "{0} Salario deve estar entre {1} e {2}")]
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
