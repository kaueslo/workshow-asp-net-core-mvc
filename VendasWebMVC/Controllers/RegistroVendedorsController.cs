﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VendasWebMVC.Controllers
{
    public class RegistroVendedorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult BuscaSimples()
		{
			return View();
		}

		public IActionResult BuscaAgrupada()
		{
			return View();
		}
	}
}
