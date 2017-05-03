using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCore.Data;

namespace WebCore.Controllers
{
    public class BlogViewController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlogViewController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: BlogView
        public ActionResult Index()
        {
            return View(_db.Blog.ToList());
        }

        // GET: BlogView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogView/Create
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

        // GET: BlogView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BlogView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogView/Delete/5
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