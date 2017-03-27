using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcContacts.Models
{
    public interface IContactRepository
    {
        void CreateNewContact(Contact contactToCreate);
        void DeleteContact(Guid id);
        Contact GetContactByID(Guid id);
        IEnumerable<Contact> GetAllContacts();
        int SaveChanges();

    }
}