using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.View_Models
{
    public class RegisterVM
    {

        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
