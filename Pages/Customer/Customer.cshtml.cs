using FarmCart.Pages.Model;
using FarmSquare.Data.dbcontext;
using FarmSquare.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FarmSquare.Pages.Customer
{
    public class CustomerModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public CustomerSignup Cust { get; set; }

        public CustomerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            var newCustomer = new CustomerTable
            {
                CustName = Cust.Name,
                CustEmail = Cust.Email,
                CustPhone = Cust.PhoneNumber,
                CustPassword = Cust.Password, 
                ConfirmPassword = Cust.ConfirmPassword 
            };

           
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            
            TempData["Message"] = "Customer registered successfully!";
            return RedirectToPage("/Customer/CustomerLogin");
        }
    }
}
