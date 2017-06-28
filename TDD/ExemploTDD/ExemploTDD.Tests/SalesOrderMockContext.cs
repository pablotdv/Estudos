using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploTDD.Tests
{
    public class SalesOrderMockContext
        : ISalesOrderContext
    {
        public SalesOrderMockContext()
        {
            Orders = new TestDbSet<SalesOrder>();
            Customers = new TestDbSet<Customer>();
        }

        public DbSet<SalesOrder> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
