using ContactControl.Models;
using ContactControl.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepos _contactRepos;
        public ContactController(IContactRepos contactRepos)
        {
            _contactRepos = contactRepos;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepos.GetAllContacts();
            return View(contacts);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepos.GetContactById(id);
            return View(contact);
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
        public IActionResult DeleteConfirm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactModel contactModel)
        {
            _contactRepos.AddContact(contactModel);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(ContactModel contactModel)
        {
            _contactRepos.UpdateContact(contactModel);
            return RedirectToAction("Index");
        }
    }
}
