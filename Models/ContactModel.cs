using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Phone is not valid")]
        public string? Phone { get; set; }
        public int? UserId { get; set; }
        public required UserModel User { get; set; }
    }
}
