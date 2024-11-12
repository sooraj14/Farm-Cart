using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Admin
{
   
      


        public class viewusersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public viewusersModel(ApplicationDbContext dbcontext)
        {
            _context= dbcontext;
        }

        public List<CustomerTable> CustomerTable { get; set; } = new List<CustomerTable>();
        public void OnGet()
        {
          CustomerTable  =_context.Customers.ToList();
            
        }
    }
}
