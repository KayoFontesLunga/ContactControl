using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ContactControl.Enums;
using ContactControl.Models;
using Newtonsoft.Json;

namespace ContactControl.Filters;

public class LoggedUserPage : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string userSession = context.HttpContext.Session.GetString("LoggedUser");
        if (string.IsNullOrEmpty(userSession))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }
        else
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }
        base.OnActionExecuting(context);
    }
}
