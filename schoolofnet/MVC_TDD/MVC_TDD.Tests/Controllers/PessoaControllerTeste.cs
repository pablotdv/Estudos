using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_TDD.Controllers;
using MVC_TDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_TDD.Tests.Controllers
{
    [TestClass]
    public class PessoaControllerTeste
    {
        PessoaController controller = new PessoaController();
        [TestMethod]
        public void Initialize()
        {

        }

        [TestMethod]
        public void Index_Pessoa()
        {
            PessoaController controller = new PessoaController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_Pessoa()
        {
            PessoaController controller = new PessoaController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.IsTrue("Meu Create" == result.ViewBag.Titulo);
        }

        [TestMethod]
        public void List_Pessoa()
        {
            
            ViewResult result = controller.List() as ViewResult;

            var count = (result.Model as IEnumerable<Pessoa>).Count();

            Assert.IsTrue(count > 0);
            
        }
    }
}
