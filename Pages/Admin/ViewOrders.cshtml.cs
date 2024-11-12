using FarmCart.Pages.Model;
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

        public List<ViewOrders> ord { get; set; }
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
            FROM OrderItem o
            LEFT JOIN CustomerTable c ON c.CustId = o.cust_id
            LEFT JOIN Product p ON p.product_id = o.product_id;
            ";          

        

            ord = _context.ViewOrder.FromSqlRaw(query).ToList();
            totalorderscount = _context.ViewOrder.Count();
        }

      

    }
}
