﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewModels;
using VendasWebMVC.Services;
using VendasWebMVC.Services.Exceções;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendasWebMVC.Controllers
{
	public class VendedoresController : Controller
	{

		private readonly ServicoVendedor _vendedorServico;
		private readonly ServicoDepartamento _servicoDepartamento;


		public VendedoresController(ServicoVendedor vendedorServico, ServicoDepartamento servicoDepartamento)
		{
			_vendedorServico = vendedorServico;
			_servicoDepartamento = servicoDepartamento;
		}


		// GET: /<controller>/
		public IActionResult Index()
		{

			var lista = _vendedorServico.AcharTodos();
			return View(lista);
		}

		public IActionResult Criar()
		{
			var departamentos = _servicoDepartamento.AcharTodos();
			var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Criar(Vendedor vendedor)
		{
			_vendedorServico.Inserir(vendedor);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Deletar(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var obj = _vendedorServico.AcharPorId(id.Value);
			if(obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Deletar(int id)
		{
			_vendedorServico.Remover(id);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Detalhes(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var obj = _vendedorServico.AcharPorId(id.Value);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		public IActionResult Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var obj = _vendedorServico.AcharPorId(id.Value);

			if (obj == null)
			{
				return NotFound();
			}

			List<Departamento> departamentos = _servicoDepartamento.AcharTodos();

			VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Editar(int id, Vendedor vendedor)
		{
			if(id != vendedor.Id)
			{
				return BadRequest();
			}
			try
			{ 
				_vendedorServico.Atualizar(vendedor);
				return RedirectToAction(nameof(Index));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
			catch (DbConcurrencyException)
			{
				return BadRequest();
			}
		}
	}
}
