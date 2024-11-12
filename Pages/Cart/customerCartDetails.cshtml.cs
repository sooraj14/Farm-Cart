/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using FarmCart.Pages.Model;

namespace FarmCart.Pages.Cart
{
    public class customerCartDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public customerCartDetailsModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<OrderProductJoin> OrderProduct { get; set; } = new List<OrderProductJoin>();

<<<<<<< HEAD
        public List<Orders> ordertabledetails { get; set; } = new List<Orders>();
=======
>>>>>>> main
        public void OnGet()
        {
            int? cut_id = HttpContext.Session.GetInt32("cust_id");

            OrderProduct = _context.Carts.Where(cart => cart.cust_id == cut_id).Join(_context.producttable, cart => cart.product_id,
                product => product.product_id, (cart, product) => new OrderProductJoin
                {
                    Product_description = product.product_description,
                    Product_id = product.product_id,
                    Product_name = product.product_name,
                    Product_image = product.imagepath,
                    Product_price = product.product_price,
                    Product_quantity = product.product_quantity
                }).ToList();
        }

        public IActionResult OnPostPlaceOrder(Dictionary<int, int> Quantities)
        {
<<<<<<< HEAD

           
=======
            Random rand = new Random();
            int? cut_id = HttpContext.Session.GetInt32("cust_id");
            if (!cut_id.HasValue)
            {
                return RedirectToPage("/Login");
            }

            var cartItems = _context.Carts.Where(c => c.cust_id == cut_id).ToList();
            if (!cartItems.Any())
            {
                return RedirectToPage("/Cart");
            }

            var order = new Orders
            {
                cust_id = cut_id.Value,
                ord_date = System.DateTime.Now,
                ord_address = "Customer's Shipping Address",
                total_amount = cartItems.Sum(c =>
                    Quantities.TryGetValue(c.product_id, out int selectedQuantity)
                        ? selectedQuantity * (_context.producttable.FirstOrDefault(p => p.product_id == c.product_id)?.product_price ?? 0)
                        : 0),
                products = string.Join(", ", cartItems.Select(c => _context.producttable
                    .FirstOrDefault(p => p.product_id == c.product_id)?.product_name ?? "Unknown"))
            };

            _context.ordertable.Add(order);
            _context.SaveChanges();

            foreach (var item in cartItems)
            {
                if (Quantities.TryGetValue(item.product_id, out int selectedQuantity))
                {
                    var orderItem = new OrderItem
                    {
                        item_ord_no = rand.Next(),
                        product_id = item.product_id,
                        product_price = _context.producttable.FirstOrDefault(p => p.product_id == item.product_id)?.product_price ?? 0,
                        product_quantity = selectedQuantity,
                        cust_id=  item.cust_id,
                        Is_Available = true
                    };

                    _context.orderitemtable.Add(orderItem);
                }
            }

            _context.SaveChanges();
            _context.Carts.RemoveRange(cartItems);
            _context.SaveChanges();

>>>>>>> main
            return RedirectToPage("/OrderPlaced");

        }

    }
}
*/


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using FarmCart.Pages.Model;

namespace FarmCart.Pages.Cart
{
    public class customerCartDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public customerCartDetailsModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<OrderProductJoin> OrderProduct { get; set; } = new List<OrderProductJoin>();
        [BindProperty]
        public int[] SelectedProducts { get; set; }
        [BindProperty]
        public Dictionary<int, int> Quantities { get; set; }

        public void OnGet()
        {
            int? cust_id = HttpContext.Session.GetInt32("cust_id");
            OrderProduct = _context.Carts
                .Where(cart => cart.cust_id == cust_id)
                .Join(_context.producttable,
                    cart => cart.product_id,
                    product => product.product_id,
                    (cart, product) => new OrderProductJoin
                    {
                        Product_description = product.product_description,
                        Product_id = product.product_id,
                        Product_name = product.product_name,
                        Product_image = product.imagepath,
                        Product_price = product.product_price,
                        Product_quantity = product.product_quantity
                    }).ToList();
        }

        public IActionResult OnPostPlaceOrder()
        {
            if (SelectedProducts == null || !SelectedProducts.Any())
            {
                TempData["Error"] = "Please select at least one product.";
                return RedirectToPage();
            }

            int? cust_id = HttpContext.Session.GetInt32("cust_id");
            if (!cust_id.HasValue)
            {
                return RedirectToPage("/Login");
            }

            // Get selected cart items
            var cartItems = _context.Carts
                .Where(c => c.cust_id == cust_id && SelectedProducts.Contains(c.product_id))
                .ToList();

            if (!cartItems.Any())
            {
                return RedirectToPage("/Cart");
            }

            // Verify product quantities and availability
            foreach (var item in cartItems)
            {
                var product = _context.producttable.FirstOrDefault(p => p.product_id == item.product_id);
                if (product == null || product.product_quantity < Quantities[item.product_id])
                {
                    TempData["Error"] = $"Product {product?.product_name ?? "Unknown"} is out of stock or has insufficient quantity.";
                    return RedirectToPage();
                }
            }

            // Create order
            var order = new Orders
            {
                cust_id = cust_id.Value,
                ord_date = System.DateTime.Now,
                ord_address = "Customer's Shipping Address",
                total_amount = cartItems.Sum(c =>
                    Quantities[c.product_id] * (_context.producttable.FirstOrDefault(p => p.product_id == c.product_id)?.product_price ?? 0)),
                products = string.Join(", ", cartItems.Select(c =>
                    _context.producttable.FirstOrDefault(p => p.product_id == c.product_id)?.product_name ?? "Unknown"))
            };

            _context.ordertable.Add(order);
            _context.SaveChanges();

            // Create order items and update product quantities
            Random rand = new Random();
            foreach (var item in cartItems)
            {
                var selectedQuantity = Quantities[item.product_id];
                var product = _context.producttable.FirstOrDefault(p => p.product_id == item.product_id);

                if (product != null)
                {
                    // Update product quantity
                    product.product_quantity -= selectedQuantity;

                    var orderItem = new OrderItem
                    {
                        item_ord_no = rand.Next(),
                        product_id = item.product_id,
                        product_price = product.product_price,
                        product_quantity = selectedQuantity,
                        cust_id = item.cust_id,
                        Is_Available = true
                    };

                    _context.orderitemtable.Add(orderItem);
                }
            }

            // Remove processed items from cart
            _context.Carts.RemoveRange(cartItems);
            _context.SaveChanges();

            return RedirectToPage("/OrderPlaced");
        }
        public IActionResult OnPostRemoveFromCart(int productId)
        {
            int? cust_id = HttpContext.Session.GetInt32("cust_id");
            if (!cust_id.HasValue)
            {
                return RedirectToPage("/Login");
            }

            var cartItem = _context.Carts.FirstOrDefault(c => c.cust_id == cust_id && c.product_id == productId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}