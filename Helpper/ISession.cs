using ContactControl.Models;

namespace ContactControl.Helpper;

public interface ISession
{
    void CreateUserSession(UserModel user);
    void RemoveUserSession();
    UserModel GetUserSession();
}
