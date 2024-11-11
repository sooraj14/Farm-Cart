using FarmCart.Data.Entity;
using FarmCart.Pages.Model;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmSquare.Pages.Supplier
{
    public class Supplier: PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public SupplierSignup Sup { get; set; }
        public Supplier (ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }
        
        public void OnGet()
        {
        }
        public IActionResult OnPostSend()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var user = new SupplierTable
            {
                sup_name = Sup.Name,
                sup_email = Sup.Email,
                sup_phone = Sup.PhoneNumber,
                //sup_location = Sup.Location,
                sup_password = Sup.Password,
                confirm_password = Sup.ConfirmPassword
            };
            _context.suptable.Add(user);
            _context.SaveChanges();
            return RedirectToPage("SupLogin");
        }
    }
}
