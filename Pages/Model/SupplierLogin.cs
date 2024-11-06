using Microsoft.AspNetCore.Mvc;

namespace FarmCart.Pages.Model
{
    public class SupplierLogin
    {
        [BindProperty]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
