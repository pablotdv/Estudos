using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSMMvcTDD.Entities;
using VSMMvcTDD.Models;
using VSMMvcTDD.Services;

namespace VSMMvcTDD.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            var contacts = _contactService.GetAllContacts()
                .Select(a=> new ContactViewModel() {
                    Id = a.Id,
                    Email = a.Email,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }).ToList();
            return View(contacts);
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
    }
}