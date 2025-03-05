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
        public IActionResult PasswordRedefine()
        {
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
                        if(user.ValidPassword(loginModel.Password))
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
        [HttpPost]
        public IActionResult EnterPasswordRedefine(PasswordRedefineModel passwordRedefineModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepos.GetByEmail(passwordRedefineModel.Email);

                    if (user != null)
                    {
                        string newPassword = user.GenerateNewPassword();
                        TempData["success"] = "We will send a new password to your email";
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["error"] = "something went wrong, we can't your password redefinied";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"something went wrong, we can't your password redefinied{ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
