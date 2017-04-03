using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        Produto[] produtos = new Produto[]
        {
            new Produto() { Codigo = 1, Nome = "Nokia Lumia", Categoria = "Celulares", Valor = 699.99M },
            new Produto() { Codigo = 2, Nome = "Samsung Galaxy", Categoria = "Celulares", Valor = 1199.99M },
            new Produto() { Codigo = 3, Nome = "Teclado", Categoria = "Informática", Valor = 130.00M },
            new Produto() { Codigo = 4, Nome = "Mouse", Categoria = "Informática", Valor = 59.95M },
            new Produto() { Codigo = 5, Nome = "Case GoPro", Categoria = "Acessórios", Valor = 65.00M },
        };

        
        public IEnumerable<Produto> GetTodos()
        {
            return produtos;
        }
        
        public IHttpActionResult Get(int codigo)
        {
            var produto = produtos.FirstOrDefault(a => a.Codigo == codigo);

            if (produto == null)
                return NotFound();

            return Json(produto);
        }

        public IEnumerable<Produto> GetPorCategoria(string categoria)
        {
            var produtos = this.produtos.Where(a => a.Categoria == categoria);

            
            return produtos;
        }


    }
}
