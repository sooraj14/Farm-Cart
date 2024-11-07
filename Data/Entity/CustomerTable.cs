using System.ComponentModel.DataAnnotations;

namespace FarmSquare.Data.Entity
{
    public class CustomerTable
    {
        [Key]
        public int CustId { get; set; }

        [Required, Display(Name = "Name")]
        public string CustName { get; set; }

        [Required, Phone, Display(Name = "Phone")]
        public string CustPhone { get; set; }

        [Required, EmailAddress, Display(Name = "Email Address")]
        public string CustEmail { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Password")]
        public string CustPassword { get; set; }

        [Required, DataType(DataType.Password), Compare("CustPassword", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
