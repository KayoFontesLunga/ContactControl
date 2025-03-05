using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;

public class PasswordRedefineModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
}
