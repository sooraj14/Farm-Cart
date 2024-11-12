using System.ComponentModel.DataAnnotations;

namespace FarmCart.Pages.Model
{
    public class SupplierSignup
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Username Required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone number")]
        [StringLength(10, ErrorMessage = "Enter the valid phone number", MinimumLength = 10)]
        public string PhoneNumber { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Password must be atleast 6 charecter", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Enter Correct Password")]
        public string ConfirmPassword { get; set; }
        public bool isvalid { get; set; }
    }
}
