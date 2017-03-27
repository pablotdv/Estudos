using MvcContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcContacts.Tests.Models
{
    public class InMemoryContactRepository : IContactRepository
    {
        private List<Contact> _db = new List<Contact>();

        public Exception ExceptionToThrow { get; set; }
        //public List<Contact> Items { get; set; }

        public void SaveChanges(Contact contactToUpdate)
        {

            foreach (Contact contact in _db)
            {
                if (contact.Id == contactToUpdate.Id)
                {
                    _db.Remove(contact);
                    _db.Add(contactToUpdate);
                    break;
                }
            }
        }

        public void Add(Contact contactToAdd)
        {
            _db.Add(contactToAdd);
        }

        public Contact GetContactByID(Guid id)
        {
            return _db.FirstOrDefault(d => d.Id == id);
        }

        public void CreateNewContact(Contact contactToCreate)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(contactToCreate);
            // return contactToCreate;
        }

        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _db.ToList();
        }

        public void DeleteContact(Guid id)
        {
            _db.Remove(GetContactByID(id));
        }
    }
}
