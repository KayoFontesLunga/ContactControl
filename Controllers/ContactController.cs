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
        public IActionResult DeleteConfirm(int id)
        {
            ContactModel contact = _contactRepos.GetContactById(id);
            return View(contact);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _contactRepos.DeleteContact(id);
                TempData["success"] = "Contact deleted successfully";
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                TempData["error"] = $"something went wrong{ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Create(ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepos.AddContact(contactModel);
                    TempData["success"] = "Contact created successfully";
                    return RedirectToAction("Index");
                }
                return View(contactModel);
            }catch(Exception ex)
            {
                TempData["error"] = $"something went wrong{ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepos.UpdateContact(contactModel);
                    TempData["success"] = "Contact updated successfully";
                    return RedirectToAction("Index");
                }
                return View(contactModel);
            }catch(Exception ex)
            {
                TempData["error"] = $"something went wrong{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
