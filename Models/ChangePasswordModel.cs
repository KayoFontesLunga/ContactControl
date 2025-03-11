using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;

public class ChangePasswordModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter your current password")]
    public string ActualPassword { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter your new password")]
    public string NewPassword { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please confirm your new password")]
    [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
