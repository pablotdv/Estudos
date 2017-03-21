using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSMMvcTDD.Entities;

namespace VSMMvcTDD.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
    }
}
