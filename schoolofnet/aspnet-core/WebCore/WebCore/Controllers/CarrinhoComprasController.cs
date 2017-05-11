using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models.Compras;
using WebCore.ViewModels;

namespace WebCore.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        public IActionResult Index()
        {
            List<Produto> lista = new List<Produto>();
            for (int i = 0; i < 5; i++)
            {
                lista.Add(new Produto() { ID = i, Nome = $"Produto {i}", Valor = (i + 1) * 2.5M });
            }

            CarrinhoComprasViewModel model = new CarrinhoComprasViewModel()
            {
                Mensagem = "Mensagem",
                Produtos = lista,
                Total = lista.Sum(a => a.Valor)
            };
            return View(model);
        }
    }
}