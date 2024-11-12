using System.ComponentModel.DataAnnotations;

namespace FarmCart.Pages.Model
{
    public class EditProfile
    {
        public int pf_id {  get; set; } 
        public string Name { get; set; }

        public string Email { get; set; }

        
        public string PhoneNumber { get; set; }

        
        public string Password { get; set; }

       
        public string ConfirmPassword { get; set; }
    }
}
