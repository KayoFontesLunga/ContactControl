using ContactControl.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ContactControl.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("LoggedUser");
            if (string.IsNullOrEmpty(userSession))
            {
                return View();
            }

            UserModel? user = JsonConvert.DeserializeObject<UserModel>(userSession);

            return View(user); 
        }
    }
}
