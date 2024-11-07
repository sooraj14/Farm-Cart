using FarmCart.Pages.Model;
using FarmSquare.Data.dbcontext;
using FarmSquare.Data.Entity;
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

<<<<<<< HEAD
        [BindProperty]
        public CustomerSignup Cust { get; set; }

        public Customer(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
           
        }

        public IActionResult OnPostSend()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var newuser = new CustomerTable
            {
                cust_name = Cust.Name,
                cust_email = Cust.Email,
                cust_phone =Cust.PhoneNumber,
                cust_password = Cust.Password,
                confirm_password = Cust.ConfirmPassword
            };
            _context.custtable.Add(newuser);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }

=======
        public CustomerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerTable Customer { get; set; }
>>>>>>> V0-LP

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
