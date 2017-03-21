using Grid.Mvc.Ajax.GridExtensions;
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
        private IAjaxGridFactory _ajaxGridFactory;

        public HomeController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            int _partitionSize = 10;
            var contacts = _contactService.GetAllContacts();
            var model = new ContactIndexModel();
            var gridData = (from contact in contacts
                           orderby contact.LastName, contact.FirstName
                           select new ContactViewModel()
                           {
                               Id = contact.Id,
                               Email = contact.Email,
                               FirstName = contact.FirstName,
                               LastName = contact.LastName
                           }).AsQueryable();
            var grid = _ajaxGridFactory.CreateAjaxGrid(gridData, 1, false, _partitionSize);
            model.Contacts = grid as AjaxGrid<ContactViewModel>;
            return View(model);
        }

        [HttpGet]
        public JsonResult ContactsGrid(int? page, bool? renderRowsOnly)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ContactViewModel();
            return PartialView("_Create", model);
        }

        [HttpPost]
        public ActionResult Create(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _contactService.AddContact(new Contact()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                });
                return Json(new { Success = true, Object = id }, JsonRequestBehavior.AllowGet);
            }
            return PartialView("_Create", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact = _contactService.GetContact(id);
            var model = new ContactViewModel()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email
            };
            return PartialView("_Edit", model);
        }

        [HttpPut]
        public ActionResult Edit(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contactService.EditContact(new Contact()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                });
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            return PartialView("_Edit", model);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
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