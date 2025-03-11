using ContactControl.Models;

namespace ContactControl.Helpper;

public interface ISessionHelper
{
    void CreateUserSession(UserModel user);
    void RemoveUserSession();
    UserModel GetUserSession();
}
