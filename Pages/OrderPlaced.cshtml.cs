using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using System.Linq;

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

        public void OnGet(int orderId)
        {
            // Fetch order details
            OrderDetails = _context.ordertable.FirstOrDefault(o => o.ord_id == orderId);

            if (OrderDetails == null)
            {
                // If order not found, redirect to cart page or show an error
                RedirectToPage("/Cart");
                return;
            }

            // Fetch order items based on the order number
            OrderItems = _context.orderitemtable
                .Where(i => i.item_ord_no == OrderDetails.ord_no)
                .ToList();

            if (OrderItems == null || !OrderItems.Any())
            {
                // Log error or handle case where there are no items in the order
                Console.WriteLine("No items found for this order.");
            }
        }
    }
}
