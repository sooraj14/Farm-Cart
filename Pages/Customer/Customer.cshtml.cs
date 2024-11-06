using FarmCart.Pages.Model;
using FarmSquare.Data.dbcontext;
using FarmSquare.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmSquare.Pages.Customer
{
    public class Customer : PageModel
    {
        private readonly ApplicationDbContext _context;

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


        public void OnGet()
        {
        }
    }
}
