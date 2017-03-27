using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContacts;
using MvcContacts.Controllers;
using MvcContacts.Models;
using System.Web;
using System.Security.Principal;
using System.Web.Routing;
using MvcContacts.Tests.Models;

namespace MvcContacts.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Contact GetContact()
        {
            return GetContact(Guid.NewGuid(), "Janet", "Gates");
        }

        Contact GetContact(Guid id, string fName, string lName)
        {
            return new Contact
            {
                Id = id,
                FirstName = fName,
                LastName = lName,
                Phone = "710-555-0173",
                Email = "janet1@adventure-works.com"
            };
        }

        private static HomeController GetHomeController(IContactRepository repository)
        {
            HomeController controller = new HomeController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            var controller = GetHomeController(new InMemoryContactRepository());

            ActionResult result = controller.Index();
            ViewResult view = (ViewResult)result;
            
            Assert.AreEqual("Index", view.ViewName);
        }

        [TestMethod]
        public void Index_Get_RetrievesAllContactsFromRepository()
        {
            Contact contact1 = GetContact(Guid.NewGuid(), "Orlando", "Gee");
            Contact contact2 = GetContact(Guid.NewGuid(), "Keith", "Harris");
            InMemoryContactRepository repository = new InMemoryContactRepository();
            repository.Add(contact1);
            repository.Add(contact2);
            var controller = GetHomeController(repository);

            var result = controller.Index();
            var view = (ViewResult)result;

            var model = (IEnumerable<Contact>)view.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), contact1);
            CollectionAssert.Contains(model.ToList(), contact2);
        }

        [TestMethod]
        public void Create_Post_ReturnsIfModelStateIsNotValid()
        {
            var controller = GetHomeController(new InMemoryContactRepository());

            controller.ModelState.AddModelError("", "mock error message");
            var model = GetContact(Guid.NewGuid(), "", "");

            var result = controller.Create(model);
            var view = (ViewResult)result;

            Assert.AreEqual("Create", view.ViewName);
        }

        [TestMethod]
        public void Create_Post_PutsValidContactIntoRepository()
        {
            var repository = new InMemoryContactRepository();
            var controller = GetHomeController(repository);
            var contact = GetContact(Guid.NewGuid(), "", "");

            controller.Create(contact);

            IEnumerable<Contact> contacts = repository.GetAllContacts();
            Assert.IsTrue(contacts.Contains(contact));
        }

        [TestMethod]
        public void Create_Post_ReturnsViewIfRepositoryThrowsException()
        {
            InMemoryContactRepository repository = new InMemoryContactRepository();
            Exception ex = new Exception();
            repository.ExceptionToThrow = ex;
            HomeController controller = GetHomeController(repository);
            Contact model = GetContact(Guid.NewGuid(), "", "");

            var result = controller.Create(model);
            var view = (ViewResult)result;

            Assert.AreEqual("Create", view.ViewName);
            ModelState modelState = view.ViewData.ModelState[""];
            Assert.IsNotNull(modelState);
            Assert.IsTrue(modelState.Errors.Any());
            Assert.AreEqual(ex, modelState.Errors[0].Exception);
        }

        [TestMethod]
        public void Create_Post_ReturnsRedirectOnSuccess()
        {
            HomeController controller = GetHomeController(new InMemoryContactRepository());

            Contact model = GetContact(Guid.NewGuid(), "", "");

            var result = controller.Create(model);
            var view = (RedirectToRouteResult)result;

            Assert.AreEqual("Index", view.RouteValues["action"]);
        }
    }
}
