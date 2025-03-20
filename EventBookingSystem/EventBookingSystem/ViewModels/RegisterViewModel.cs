using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage="Password and Confirm Password didnot match")]
        public string ConfirmPassword { get; set; }
    }
}
