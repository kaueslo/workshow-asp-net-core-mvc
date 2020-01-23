using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Models;
using VendasWebMVC.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendasWebMVC.Controllers
{
	public class VendedoresController : Controller
	{

		private readonly ServicoVendedor _vendedorServico; 
		public VendedoresController(ServicoVendedor vendedorServico)
		{
			_vendedorServico = vendedorServico;
		}


		// GET: /<controller>/
		public IActionResult Index()
		{

			var lista = _vendedorServico.AcharTodos();
			return View(lista);
		}

		public IActionResult Criar()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Criar(Vendedor vendedor)
		{
			_vendedorServico.Inserir(vendedor);
			return RedirectToAction(nameof(Index));
		}
	}
}
