using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using FarmCart.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace FarmCart.Pages.Cart
{
    public class buynowModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public buynowModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public OrderProductJoin Product { get; set; }
        public decimal TotalPrice { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        public IActionResult OnGet(int product_id)
        {
            int? cust_id = HttpContext.Session.GetInt32("cust_id");
            if (!cust_id.HasValue)
            {
                return RedirectToPage("/Login");
            }

            Product = _context.producttable
                .Where(p => p.product_id == product_id)
                .Select(p => new OrderProductJoin
                {
                    Product_id = p.product_id,
                    Product_name = p.product_name,
                    Product_description = p.product_description,
                    Product_price = p.product_price,
                    Product_quantity = p.product_quantity,
                    Product_image = p.imagepath
                })
                .FirstOrDefault();

            if (Product == null)
            {
                return RedirectToPage("/Index");
            }

            Quantity = 1;
            TotalPrice = Product.Product_price;

            return Page();
        }

        public IActionResult OnPostPlaceOrder(int product_id, int quantity)
        {
            int? cust_id = HttpContext.Session.GetInt32("cust_id");
            if (!cust_id.HasValue)
            {
                return RedirectToPage("/Login");
            }

            var product = _context.producttable.FirstOrDefault(p => p.product_id == product_id);
            if (product == null || product.product_quantity < quantity)
            {
                TempData["Error"] = "Product is out of stock or does not have the requested quantity.";
                return RedirectToPage(new { product_id });
            }

            TotalPrice = product.product_price * quantity;

            var order = new Orders
            {
                cust_id = cust_id.Value,
                ord_date = DateTime.Now,
                ord_address = "Customer's Shipping Address",
                total_amount = (int)TotalPrice,
                products = product.product_name
            };
            _context.ordertable.Add(order);
            _context.SaveChanges();

            var orderItem = new OrderItem
            {
                item_ord_no = new Random().Next(),
                product_id = product_id,
                product_price = product.product_price,
                product_quantity = quantity,
                cust_id = cust_id.Value,
                Is_Available = true
            };
            _context.orderitemtable.Add(orderItem);

            product.product_quantity -= quantity;
            _context.SaveChanges();

            return RedirectToPage("/OrderPlaced");
        }
    }
}
