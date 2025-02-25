using ContactControl.Data;
using ContactControl.Models;

namespace ContactControl.Repos
{
    public class ContactRepos : IContactRepos
    {
        private readonly BancContext _context;
        public ContactRepos(BancContext context)
        {
            _context = context;
        }
        public List<ContactModel> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }
        public ContactModel AddContact(ContactModel contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }
        public ContactModel UpdateContact(ContactModel contact)
        {
            ContactModel contactDB = GetContactById(contact.Id);

            if (contactDB == null)
                throw new InvalidOperationException("Contact not found");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Phone = contact.Phone;

            _context.Contacts.Update(contactDB);
            _context.SaveChanges();
            return contactDB;
        }
        public ContactModel GetContactById(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                throw new InvalidOperationException("Contact not found");
            }
            return contact;
        }
        public bool DeleteContact(int id)
        {
            ContactModel contactDB = GetContactById(id);

            if (contactDB == null)
                throw new InvalidOperationException("Contact not found");

            _context.Contacts.Remove(contactDB);
            _context.SaveChanges();
            return true;
        }
    }
}
