using ContactControl.Helpper;
using ContactControl.Models;
using ContactControl.Repos;
using Microsoft.AspNetCore.Mvc;
using ISessionHelper = ContactControl.Helpper.ISessionHelper;

namespace ContactControl.Controllers
{
    public class LoginController(IUserRepos userRepos, ISessionHelper session, IEmail email) : Controller
    {
        private readonly IUserRepos _userRepos = userRepos;
        private readonly ISessionHelper _session = session;
        private readonly IEmail _email = email;

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
                        string message = $"Your new password is: {newPassword}";
                        bool result = _email.SendEmail(user.Email, "ContactControl - New Password", $"Your new password is: {newPassword}");
                        if (result)
                        {
                            _userRepos.UpdateUser(user);
                            TempData["success"] = "We will send a new password to your email";
                        }
                        else
                        {
                            TempData["error"] = "something went wrong, we can't send your password redefinied";
                        }
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["error"] = "something went wrong, we can't send your password redefinied";
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
