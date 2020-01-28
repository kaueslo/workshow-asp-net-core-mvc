using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class RegistroVendedorsController : Controller
    {

		private readonly ServicoRegistroVendas _servicoRegistroVendas;

		public RegistroVendedorsController(ServicoRegistroVendas servicoRegistroVendas)
		{
			_servicoRegistroVendas = servicoRegistroVendas;
		}

		public IActionResult Index()
        {
            return View();
        }

		public async Task<IActionResult> BuscaSimples(DateTime? dtMin, DateTime? dtMax)
		{
			if (!dtMin.HasValue)
			{
				dtMin = new DateTime(DateTime.Now.Year, 1, 1);
			}
			if (!dtMax.HasValue)
			{
				dtMax = DateTime.Now;
			}

			ViewData["dtMin"] = dtMin.Value.ToString("yyyy-MM-dd");
			ViewData["dtMax"] = dtMax.Value.ToString("yyyy-MM-dd");

			var resultado = await _servicoRegistroVendas.AchePorDataAsync(dtMin, dtMax);
			return View(resultado);
		}

		public async Task<IActionResult> BuscaAgrupada(DateTime? dtMin, DateTime? dtMax)
		{
			if (!dtMin.HasValue)
			{
				dtMin = new DateTime(DateTime.Now.Year, 1, 1);
			}
			if (!dtMax.HasValue)
			{
				dtMax = DateTime.Now;
			}

			ViewData["dtMin"] = dtMin.Value.ToString("yyyy-MM-dd");
			ViewData["dtMax"] = dtMax.Value.ToString("yyyy-MM-dd");

			var resultado = await _servicoRegistroVendas.AchePorDataAgrupadaAsync(dtMin, dtMax);
			return View(resultado);
		}
	}
}
