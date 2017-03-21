using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSMMvcTDD;
using VSMMvcTDD.Controllers;
using Moq;
using VSMMvcTDD.Services;
using VSMMvcTDD.Entities;
using VSMMvcTDD.Models;

namespace VSMMvcTDD.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IContactService> _mockContactService;
        private HomeController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockContactService = new Mock<IContactService>();
            _controller = new HomeController(_mockContactService.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockContactService.VerifyAll();
        }

        [TestMethod]
        public void Index_ExpectViewResultReturned()
        {
            var stubContacts = new List<Contact>()
            {
                new Contact()
                {
                    Id= 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@email.com",
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "janedoe@email.com",
                }
            };

            _mockContactService.Setup(x => x.GetAllContacts()).Returns(stubContacts);
            var expectedModel = new List<ContactViewModel>();
            foreach (var stubContact in stubContacts)
            {
                expectedModel.Add(new ContactViewModel()
                {
                    Id = stubContact.Id,
                    Email = stubContact.Email,
                    FirstName = stubContact.FirstName,
                    LastName = stubContact.LastName,
                });
            }

            var result = _controller.Index() as ViewResult;

            var actualModel = result.Model as List<ContactViewModel>;

            for (int i = 0; i < expectedModel.Count; i++)
            {
                Assert.AreEqual(expectedModel[i].Id, actualModel[i].Id);
                Assert.AreEqual(expectedModel[i].Email, actualModel[i].Email);
                Assert.AreEqual(expectedModel[i].FirstName, actualModel[i].FirstName);
                Assert.AreEqual(expectedModel[i].LastName, actualModel[i].LastName);
            }
        }        

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
