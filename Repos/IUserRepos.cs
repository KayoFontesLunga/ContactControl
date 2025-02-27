﻿using ContactControl.Models;

namespace ContactControl.Repos
{
    public interface IUserRepos
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        UserModel AddUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        bool DeleteUser(int id);
    }
}
