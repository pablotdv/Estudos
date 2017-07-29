using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exemplos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Capitulo01_TestMultiplication()
        {
            Dollar five = new Dollar(5);
            five.Times(2);
            Assert.AreEqual(10, five.Amount);
        }

        [TestMethod]
        public void Capitulo02_TestMultiplication()
        {
            Dollar five = new Dollar(5);
            Dollar product = five.Times(2);            
            Assert.AreEqual(10, product.Amount);
            product = five.Times(3);
            Assert.AreEqual(15, product.Amount);
        }
    }
}
