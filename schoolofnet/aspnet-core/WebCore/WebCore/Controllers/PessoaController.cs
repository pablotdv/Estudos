using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models.PessoaViewModels;

namespace WebCore.Controllers
{
    [Route("Publish")]
    public class PessoaController : Controller
    {
        [Route("")]
        [Route("Coisa")]
        [Route("IndexP")]
        public IActionResult Index()
        {            
            return View();
        }

        [Route("DiferenteP")]
        public IActionResult Diferente()
        {
            Pessoa pessoa = new Pessoa()
            {
                Nome = "Pablo Tôndolo de Vargas",
                DataNascimento = new DateTime(1986, 12, 12)
            };
            return View(pessoa);
        }

        [Route("TesteP")]
        public IActionResult Teste()
        {
            return View("Index");
        }

        [Route("ViewModelP")]
        public IActionResult ViewModel(int? id)
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