using FarmCart.Pages.Model;
using FarmSquare.Data.dbcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Supplier
{
    public class LoginModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public SupplierLogin User { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPostSend()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var authUser = _context.suptable.Where(p => p.sup_email == User.Email && p.sup_password == User.Password).FirstOrDefault();
            if (authUser!= null)
            {
             
                return RedirectToPage("SupHome");
            }
            else
            {
                Console.WriteLine("No Data Found");
            }
            return Page();
        }
    }
}
