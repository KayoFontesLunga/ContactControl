using ContactControl.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    [LoggedUserPage]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
