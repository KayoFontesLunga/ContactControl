using ContactControl.Enums;
using ContactControl.Helpper;
using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Login is required")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Profile is required")]
        public ProfileEnum? Profile { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? DataUpdate { get; set; }
        public bool ValidPassword(string password)
        {
            return Password == password.Encrypt();
        }
        public void SetPassword()
        {
            Password = Password.Encrypt();
        }
        public void SetNewPassword(string newPassword)
        {
            Password = newPassword.Encrypt();
        }
        public string GenerateNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPassword.Encrypt();
            return newPassword;
        }
    }
}
