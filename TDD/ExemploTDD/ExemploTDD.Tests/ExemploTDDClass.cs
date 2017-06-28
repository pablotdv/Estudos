using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ExemploTDD.Tests
{
    [TestClass]
    public class ExemploTDDClass
    {
        SalesOrderMockContext mockCtx;
        [TestInitialize]
        public void StockContextWithCustomers()
        {

            mockCtx = new SalesOrderMockContext();

            mockCtx.Customers.Add(new Customer()
            {
                CustomerId = 1,
                FirstName = "Peter",
                LastName = "Vogel"
            });

            mockCtx.Customers.Add(new Customer()
            {
                CustomerId = 2,
                FirstName = "Jan",
                LastName = "Vogel"
            });
        }

        [TestMethod]
        public async Task GetCustomer()
        {
            var res = await (from c in mockCtx.Customers
                             where c.FirstName == "Peter"
                             select c).FirstOrDefaultAsync();
            Assert.IsNotNull(res, "No customer found");
            Assert.AreEqual(1, res.CustomerId, "Wrong customer found");
        }
    }
}
