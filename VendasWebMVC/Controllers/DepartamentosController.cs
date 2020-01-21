using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Models;

namespace VendasWebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {

			List<Departamento> lista = new List<Departamento>();

			lista.Add(new Departamento { Id = 1, Nome = "Eletronicos" });
			lista.Add(new Departamento { Id = 2, Nome = "Games" });


            return View(lista);
        }
    }
}