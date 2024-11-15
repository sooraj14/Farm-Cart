using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Supplier
{
    public class SupHomeModel : PageModel
    {
        public IActionResult OnGet()
        {
           int? var =  HttpContext.Session.GetInt32("IsAuthenticated");
            if(var == null)
            {
                return RedirectToPage("/Supplier/SupLogin");
            }

            return Page();
        }

    }
}
