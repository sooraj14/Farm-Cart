using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FarmCart.Pages.Admin
{
    public class AdminDashboardModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public List<string> productname { get; set; } = new List<string>();
        public List<int> productsale { get; set; } = new List<int>();
        public AdminDashboardModel(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }
        public List<Product> totalcount { get; set; }
        
        public int totalcountofproduct { get; set; }
        public int totalcountoforders { get; set; }

        public List<Orders> ordtrans { get; set; }

        public int totaltransaction { get; set; }
        public int totalusers {  get; set; }
        public int totalsupplier { get; set; }
        public IActionResult OnGet()
        {
            int? val = HttpContext.Session.GetInt32("Athuentication");
            if(val == null)
            {
                return RedirectToPage("/Admin/Admin");
            }
            totalcountofproduct = _context.producttable.Count();
            totalcountoforders = _context.ordertable.Count();
            totalsupplier= _context.suptable.Count();
            totalusers = _context.Customers.Count();
            totaltransaction = _context.ordertable.Select(o => o.total_amount).Sum();


            //   Fetch data from  Database
            var orderdata= _context.producttable.Select(v=>  new { v.product_name, v.product_quantity }).ToList();

            // add fetched data to the created list

            productname = orderdata.Select(v => v.product_name).ToList();
            productsale = orderdata.Select(v => v.product_quantity).ToList();
            return Page();

        }
    }
}
