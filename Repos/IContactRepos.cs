using ContactControl.Models;

namespace ContactControl.Repos
{
    public interface IContactRepos
    {
        List<ContactModel> GetAllContacts();
        ContactModel GetContactById(int id);
        ContactModel AddContact(ContactModel contact);
        ContactModel UpdateContact(ContactModel contact);
        //void DeleteContact(int id);
    }
}
