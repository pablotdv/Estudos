using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AngularJSSinglePageApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Teste()
        {
            return View();
        }

        public IActionResult Teste2()
        {
            return View();
        }

        public IActionResult Teste3()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
