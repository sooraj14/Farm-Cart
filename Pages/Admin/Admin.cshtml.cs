using FarmCart.Pages.ModelClass;
using FarmCart.Data.dbcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Admin
{
    public class Admin : PageModel
    {
        public readonly ApplicationDbContext _context;
        [BindProperty]

        public AdminClass adminclass { get; set; }


        public Admin(ApplicationDbContext context)
        {
            _context = context;

        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if ((adminclass.Adminemail.Equals("admin@123")) && (adminclass.Adminpassowrd.Equals("admin")))
            {
                return RedirectToPage("AdminDashboard");
            }
            else
            {
                TempData["messageLoginfailed"] = "Login Failed";
                return RedirectToPage();
            }
        }
    }
}
