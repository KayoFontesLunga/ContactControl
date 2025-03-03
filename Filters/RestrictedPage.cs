using ContactControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ContactControl.Enums;

namespace ContactControl.Filters;

public class RestrictedPage : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string userSession = context.HttpContext.Session.GetString("LoggedUser");
        if (string.IsNullOrEmpty(userSession))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new{ controller = "Login", action = "Index"}));
        }
        else
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new {controller = "login", action = "Index"}));
            }
            if (user.Profile != ProfileEnum.Admin)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Restrict", action = "Index" }));
            }
        }
            base.OnActionExecuting(context);
    }
}
