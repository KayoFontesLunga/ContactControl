using ContactControl.Models;

namespace ContactControl.Repos
{
    public interface IContactRepos
    {
        List<ContactModel> GetAllContacts(int userId);
        ContactModel GetContactById(int id);
        ContactModel AddContact(ContactModel contact);
        ContactModel UpdateContact(ContactModel contact);
        bool DeleteContact(int id);
    }
}
