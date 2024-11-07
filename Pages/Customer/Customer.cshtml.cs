using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FarmSquare.Data;
using FarmSquare.Data.Entity;
using System.Threading.Tasks;
using FarmSquare.Data.dbcontext;

namespace FarmSquare.Pages.Customer
{
    public class CustomerModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CustomerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerTable Customer { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer); 
            await _context.SaveChangesAsync();

            TempData["Message"] = "Customer registered successfully!";
            return RedirectToPage("CustomerLogin");
        }
    }
}
