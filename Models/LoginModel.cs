using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(4, ErrorMessage = "Password must be at least 4 characters")]
    public string? Password { get; set; }
}
