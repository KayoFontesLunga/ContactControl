using ContactControl.Models;

namespace ContactControl.Repos
{
    public interface IUserRepos
    {
        UserModel GetByLogin(string login);
        UserModel GetByEmail(string email);
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        UserModel AddUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        UserModel ChangePassword(ChangePasswordModel changePasswordModel);
        bool DeleteUser(int id);
    }
}
