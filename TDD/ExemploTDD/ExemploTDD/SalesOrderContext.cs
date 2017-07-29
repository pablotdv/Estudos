using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploTDD
{
    public class SalesOrderContext : DbContext, ISalesOrderContext
    {
        public DbSet<SalesOrder> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
