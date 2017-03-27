using MvcContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcContacts.Controllers
{
    public class HomeController : Controller
    {
        IContactRepository _repository;

        public HomeController()
            : this(new EntityContactManagerRepository())
        {

        }

        public HomeController(IContactRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View("Index", _repository.GetAllContacts());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Contact model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateNewContact(model);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex);
                ViewData["CreateError"] = "Unable to create; view innerexception";
            }

            return View("Create");
        }
    }
}