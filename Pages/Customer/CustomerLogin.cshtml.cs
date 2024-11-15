using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FarmCart.Data.dbcontext; 
using System.Linq;
using System.Threading.Tasks;
using FarmCart.Pages.ModelClass;
using Microsoft.AspNetCore.Http;

namespace FarmCart.Pages.Customer
{
    public class CustomerLoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CustomerLoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerLoginTable Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.Customers
                .FirstOrDefault(u => u.CustEmail == Login.Email && u.CustPassword == Login.Password);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
                return RedirectToPage(); 
            }

            HttpContext.Session.SetInt32("cust_id", user.CustId);
            TempData["SuccessMessage"] = "Login successful!";
            return RedirectToPage("/Index");
        }

    }
}
