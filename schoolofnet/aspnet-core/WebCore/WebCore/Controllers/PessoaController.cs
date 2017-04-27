using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models.PessoaViewModels;

namespace WebCore.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Diferente()
        {
            Pessoa pessoa = new Pessoa()
            {
                Nome = "Pablo Tôndolo de Vargas",
                DataNascimento = new DateTime(1986, 12, 12)
            };
            return View(pessoa);
        }

        public IActionResult Teste()
        {
            return View("Index");
        }

        public IActionResult ViewModel()
        {
            Pessoa pessoa = new Pessoa()
            {
                Nome = "Pablo Tôndolo de Vargas",
                DataNascimento = new DateTime(1986, 12, 12)
            };
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(pessoa);
            return View("Carrega", lista);
        }
    }
}