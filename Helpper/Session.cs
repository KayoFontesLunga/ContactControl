using ContactControl.Models;
using Newtonsoft.Json;

namespace ContactControl.Helpper;

public class Session : ISession
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public Session(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public void CreateUserSession(UserModel user)
    {
        string value = JsonConvert.SerializeObject(user);
        _httpContextAccessor.HttpContext.Session.SetString("LoggedUser", value);
    }
    
    public UserModel GetUserSession()
    {
        string userSession = _httpContextAccessor.HttpContext.Session.GetString("LoggedUser");
        if (string.IsNullOrEmpty(userSession))
        {
            return null;
        }
        else
        {
            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }
    }
    public void RemoveUserSession()
    {
        _httpContextAccessor.HttpContext.Session.Remove("LoggedUser");
    }
}
