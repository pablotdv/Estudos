using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcContacts.Models
{
    public class EntityContactManagerRepository : IContactRepository
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public Contact GetContactByID(Guid id)
        {
            return _db.Contacts.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _db.Contacts.ToList();
        }

        public void CreateNewContact(Contact contactToCreate)
        {
            _db.Contacts.Add(contactToCreate);
            _db.SaveChanges();
            //   return contactToCreate;
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteContact(Guid id)
        {
            var conToDel = GetContactByID(id);
            _db.Contacts.Remove(conToDel);
            _db.SaveChanges();
        }

    }
}