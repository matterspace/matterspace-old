using System.ComponentModel.DataAnnotations;

namespace Matterspace.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}