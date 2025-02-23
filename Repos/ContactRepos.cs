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
        public ContactModel GetContactById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
