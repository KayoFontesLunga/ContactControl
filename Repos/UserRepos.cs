using ContactControl.Data;
using ContactControl.Models;

namespace ContactControl.Repos
{
    public class UserRepos(BancContext context) : IUserRepos
    {
        private readonly BancContext _context = context;

        public UserModel GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(x => x.Email == login);
        }
        public UserModel GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }
        public List<UserModel> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public UserModel AddUser(UserModel user)
        {
            user.RegistrationDate = DateTime.Now;
            user.SetPassword();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public UserModel UpdateUser(UserModel user)
        {
            UserModel userDB = GetUserById(user.Id);

            if (userDB == null)
                throw new InvalidOperationException("Contact not found");

            userDB.Name = user.Name;
            userDB.Email = user.Email;
            userDB.Login = user.Login;
            userDB.Profile = user.Profile;
            userDB.DataUpdate = DateTime.Now;

            _context.Users.Update(userDB);
            _context.SaveChanges();
            return userDB;
        }
        public UserModel GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new InvalidOperationException("Contact not found");
            }
            return user;
        }
        public bool DeleteUser(int id)
        {
            UserModel userDB = GetUserById(id);

            if (userDB == null)
                throw new InvalidOperationException("Contact not found");

            _context.Users.Remove(userDB);
            _context.SaveChanges();
            return true;
        }
    }
}
