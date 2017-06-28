using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploTDD
{
    public interface ISalesOrderContext
    {
        DbSet<SalesOrder> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }

        int SaveChanges();
    }
}
