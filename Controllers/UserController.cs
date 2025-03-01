using ContactControl.Models;
using ContactControl.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepos _userRepos;
        public UserController(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepos.GetAllUsers();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepos.AddUser(userModel);
                    TempData["success"] = "User created successfully";
                    return RedirectToAction("Index");
                }
                return View(userModel);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"something went wrong{ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            UserModel user = _userRepos.GetUserById(id);
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepos.DeleteUser(id);
                TempData["success"] = "User deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"something went wrong{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
