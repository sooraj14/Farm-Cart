/*using FarmCart.Pages.Model;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace FarmCart.Pages.Admin
{
    public class ViewOrdersModel : PageModel
    {
 
        private readonly ApplicationDbContext _context;

        public ViewOrdersModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
          
        }

        public List<ViewOrders> ord { get; set; } = new List<ViewOrders>();

        public ViewOrders vo { get; set; } = new ViewOrders();
        public int totalorderscount { get; set; } = 0;
        public void OnGet()
        {
            var query = @"
                  SELECT 
                      ROW_NUMBER() OVER (ORDER BY o.cust_id) AS Id, 
                      o.cust_id, 
                      o.product_id, 
                      o.product_price, 
                      o.product_quantity,
                      p.product_name, 
                      c.CustName, 
                      c.CustEmail, 
                      c.CustPhone
                  FROM OrderItemtable o
                  LEFT JOIN Customers c ON c.CustId = o.cust_id
                  LEFT JOIN producttable p ON p.product_id = o.product_id;
                  ";
            var store = new ViewOrders
            {
                product_name = vo.product_name,
                CustName = vo.CustName,
                product_price= vo.product_price,
                product_quantity = vo.product_quantity,
                CustEmail=vo.CustEmail,
                CustPhone=vo.CustPhone


            };

            _context.ViewOrder.Add(store);
            ord = _context.ViewOrder.ToList();
            
            totalorderscount = _context.ViewOrder.Count();
        }

      

    }
}*/

using FarmCart.Pages.Model;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FarmCart.Pages.Admin
{
    public class ViewOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ViewOrdersModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<ViewOrders> ord { get; set; } = new List<ViewOrders>();
        public int totalorderscount { get; set; } = 0;

        public IActionResult OnGet()
        {
            int? val = HttpContext.Session.GetInt32("Athuentication");
            if (val == null)
            {
                return RedirectToPage("/Admin/Admin");
            }

            ord = (from o in _context.orderitemtable
                   join c in _context.Customers
                       on o.cust_id equals c.CustId
                   join p in _context.producttable
                       on o.product_id equals p.product_id 
                   orderby o.cust_id
                   select new ViewOrders
                   {
                       product_id= p.product_id,
                       cust_id= c.CustId,
                       product_name = p != null ? p.product_name : "Unknown Product",
                       CustName = c != null ? c.CustName : "Unknown Customer",
                       product_price = o.product_price, 
                       product_quantity = o.product_quantity,
                       CustEmail = c.CustEmail,
                       CustPhone = c.CustPhone
                   }).ToList();

        
            totalorderscount = ord.Count();
            return Page();
        }
    }
}




/*into customerGroup
from c in customerGroup.DefaultIfEmpty() */  
// used in left join operation when even  a both table doenot have a matching coloum it should store that coloums as null and perform join.