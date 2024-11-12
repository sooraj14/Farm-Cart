using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Admin
{
    public class AdminDashboardModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public AdminDashboardModel(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }
        public List<Product> totalcount { get; set; }
        
        public int totalcountofproduct { get; set; }
        public int totalcountoforders { get; set; }

        public int totalusers {  get; set; }
        public int totalsupplier { get; set; }
        public void OnGet()
        {
            totalcountofproduct = _context.producttable.Count();
            totalcountoforders = _context.ordertable.Count();
            totalsupplier= _context.suptable.Count();
            totalusers = _context.Customers.Count();

        }
    }
}
