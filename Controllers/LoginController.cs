using ContactControl.Models;
using ContactControl.Repos;
using Microsoft.AspNetCore.Mvc;
using ISession = ContactControl.Helpper.ISession;

namespace ContactControl.Controllers
{
    public class LoginController(IUserRepos userRepos, ISession session) : Controller
    {
        private readonly IUserRepos _userRepos = userRepos;
        private readonly ISession _session = session;

        public IActionResult Index()
        {
            if (_session.GetUserSession() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Logout()
        {
            _session.RemoveUserSession();
            return RedirectToAction("Index", "Login");
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
                            _session.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }
                       
                        
                        TempData["error"] = "Invalid password";
                       
                    }
                    TempData["error"] = "Invalid login";
                }
                return View("Index", loginModel);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"something went wrong{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
