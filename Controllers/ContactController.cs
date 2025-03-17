using ContactControl.Filters;
using ContactControl.Helpper;
using ContactControl.Models;
using ContactControl.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    [LoggedUserPage]
    public class ContactController : Controller
    {
        private readonly IContactRepos _contactRepos;
        private readonly ISessionHelper _session;
        public ContactController(IContactRepos contactRepos, ISessionHelper session)
        {
            _contactRepos = contactRepos;
            _session = session;
        }
        [HttpGet]
        public IActionResult Index()
        {
            UserModel user = _session.GetUserSession();
            List<ContactModel> contacts = _contactRepos.GetAllContacts(user.Id);
            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepos.GetContactById(id);
            return View(contact);
        }
        [HttpGet]
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
                    UserModel user = _session.GetUserSession();
                    contactModel.UserId = user.Id;
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
                    UserModel user = _session.GetUserSession();
                    contactModel.UserId = user.Id;
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
