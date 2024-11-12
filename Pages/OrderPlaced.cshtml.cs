using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
<<<<<<< HEAD
using System.Linq;
using FarmCart.Pages.Model;
=======
using System.Collections.Generic;
>>>>>>> main

namespace FarmCart.Pages
{
    public class OrderPlacedModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OrderPlacedModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Orders OrderDetails { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }

<<<<<<< HEAD
        public OrderProductJoin orddetails { get;  set; }
        public void OnGet(int orderId)
=======
        public IActionResult OnGet()
>>>>>>> main
        {
            int? customerId = HttpContext.Session.GetInt32("cust_id");
            if (!customerId.HasValue)
            {
                return RedirectToPage("/Login");
            }

            
            OrderDetails = _context.ordertable.Where(o => o.cust_id == customerId.Value).OrderByDescending(o => o.ord_date).FirstOrDefault();

            if (OrderDetails == null)
            {
                return RedirectToPage("/Cart");
            }

           
            OrderItems = _context.orderitemtable
                .Where(oi => oi.cust_id == OrderDetails.cust_id)  
                .ToList();

            return Page();
        }


       
           
        
    }
}
