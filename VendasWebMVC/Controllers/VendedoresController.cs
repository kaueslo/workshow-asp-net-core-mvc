using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		public async Task<IActionResult> Index()
		{

			var lista = await _vendedorServico.AcharTodosAsync();
			return View(lista);
		}

		public async Task<IActionResult> Criar()
		{
			var departamentos = await _servicoDepartamento.AcharTodosAsync();
			var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Criar(Vendedor vendedor)
		{
			if (!ModelState.IsValid)
			{
				var departamentos = await _servicoDepartamento.AcharTodosAsync();
				var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
				return View(viewModel);
			}
			await _vendedorServico.InserirAsync(vendedor);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Deletar(int? id)
		{
			if(id == null)
			{
				return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });
			}

			var obj = await _vendedorServico.AcharPorIdAsync(id.Value);
			if(obj == null)
			{
				return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Deletar(int id)
		{
			await _vendedorServico.RemoverAsync(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Detalhes(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });
			}

			var obj = await _vendedorServico.AcharPorIdAsync(id.Value);
			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });
			}

			return View(obj);
		}

		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });
			}

			var obj = await _vendedorServico.AcharPorIdAsync(id.Value);

			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });
			}

			List<Departamento> departamentos = await _servicoDepartamento.AcharTodosAsync();

			VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(int id, Vendedor vendedor)
		{
			if (!ModelState.IsValid)
			{
				var departamentos = await  _servicoDepartamento.AcharTodosAsync();
				var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
				return View(viewModel);
			}

			if (id != vendedor.Id)
			{
				return RedirectToAction(nameof(Error), new { mensagem = "Id não corresponde" });
			}
			try
			{ 
				await _vendedorServico.AtualizarAsync(vendedor);
				return RedirectToAction(nameof(Index));
			}
			catch (ApplicationException e)
			{
				return RedirectToAction(nameof(Error), new { mensagem =e.Message });
			}

		}

		public IActionResult Error(string mensagem)
		{
			var viewModel = new ErrorViewModel
			{
				Mensagem = mensagem,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			};
			return View(viewModel);
		}
	}
}
