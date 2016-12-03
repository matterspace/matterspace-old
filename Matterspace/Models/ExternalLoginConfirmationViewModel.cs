using System.ComponentModel.DataAnnotations;

namespace Matterspace.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        [RegularExpression("^([a-z0-9](?:-?[a-z0-9]){0,39})$", ErrorMessage = "Invalid user name. User names can only contain alphanumeric characters and hyphens; They cannot start with, end with, or have consecutive hyphens. The maximum size is 40 characters")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}