using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models.PessoaViewModels;

namespace WebCore.Controllers
{
    public class PessoaRWController : Controller
    {
        // GET: PessoaRW
        public ActionResult Index()
        {
            return View();
        }

        // GET: PessoaRW/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PessoaRW/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaRW/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaRW/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = new Pessoa()
            {
                Nome = $"Pablo Tôndolo de Vargas (id = {id})",
                DataNascimento = new DateTime(1986, 12, 12)
            };
            return View(pessoa);
        }

        // POST: PessoaRW/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pessoa pessoa)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaRW/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaRW/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}