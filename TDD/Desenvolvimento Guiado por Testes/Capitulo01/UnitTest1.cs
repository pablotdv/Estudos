using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo01
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMultiplication()
        {
            Dollar five = new Dollar(5);
            five.Times(2);
            Assert.AreEqual(10, five.Amount);
        }
    }
}
