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
        public IActionResult Edit()
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
    }
}
