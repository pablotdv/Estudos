using MVC_TDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TDD.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Titulo = "Meu Create";

            return View();
        }

        public ActionResult List()
        {
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa("000","Joao") {  });
            return View(lista);
        }
    }
}