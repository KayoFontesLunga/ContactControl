using ContactControl.Models;
using ContactControl.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class LoginController(IUserRepos userRepos) : Controller
    {
        private readonly IUserRepos _userRepos = userRepos;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterLogin(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepos.GetByLogin(loginModel.Email);

                    if (user != null)
                    {
                        if(user.Password == loginModel.Password)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["error"] = "Invalid password";
                        }
                    }
                    TempData["error"] = "Invalid login";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"something went wrong{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
