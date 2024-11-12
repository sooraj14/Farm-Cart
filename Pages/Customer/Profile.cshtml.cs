using FarmCart.Data.dbcontext;
using FarmCart.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Customer
{
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ProfileModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public EditProfile newpf { get; set; } = new EditProfile();
        
        public IActionResult OnGet()
        {
            int? id = HttpContext.Session.GetInt32("cust_id");
            if(id == null)
            {
                return Page();
            }
            var newcust =_context.Customers.Find(id);
            newpf = new EditProfile
            {
                pf_id = newcust.CustId,
                Name = newcust.CustName,
                Email = newcust.CustEmail,
                PhoneNumber = newcust.CustPhone,
                Password = newcust.CustPassword,
                ConfirmPassword = newcust.ConfirmPassword
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            int? id = HttpContext.Session.GetInt32("cust_id");
            var newcust = _context.Customers.Find(id);
            if(newcust == null)
            {
                return NotFound();
            }
            else
            {
                newcust.CustName = newpf.Name;
                newcust.CustEmail = newpf.Email;
                newcust.CustPhone = newpf.PhoneNumber;
                newcust.CustPassword = newpf.Password;
                newcust.ConfirmPassword = newpf.ConfirmPassword;

            }

            _context.SaveChanges();
            return RedirectToPage("/Customer/CustomerLogin");
        }
    }
}
