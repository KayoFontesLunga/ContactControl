using ContactControl.Helpper;
using ContactControl.Models;
using ContactControl.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly IUserRepos _userRepos;
        private readonly ISessionHelper _session;
        public ChangePasswordController(IUserRepos userRepos, ISessionHelper  session)
        {
            _userRepos = userRepos;
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _session.GetUserSession();
                    changePasswordModel.Id = user.Id;
                    _userRepos.ChangePassword(changePasswordModel);
                    TempData["success"] = "Password changed successfully";
                    return View("Index", changePasswordModel);
                }
                return View("Index", changePasswordModel);
            }
            catch
            {
                TempData["error"] = "something went wrong. Please try again";
                return View("Index", changePasswordModel);
            }
        }
    }
}
