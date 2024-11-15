using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using FarmCart.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FarmCart.Pages.Cart
{
    public class CartandOrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CartandOrderModel(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public CartDetails carstd { get; set; } = new CartDetails();
        public List<Product> prodlist { get; set; } = new List<Product>();
        public Product SingleProduct { get; set; }
        public bool IsBuyNow { get; set; }

        public void OnGet(int product_id, bool buyNow = false)
        {
            var pid = TempData["ProductId"] ?? product_id;
            if (buyNow)
            {
                SingleProduct = _context.producttable.FirstOrDefault(p => p.product_id == (int)pid);
                IsBuyNow = true;
            }
            else
            {
                prodlist = _context.producttable.Where(p => p.product_id == (int)pid).ToList();
            }
        }
        

        public IActionResult OnPostCart(int product_id)
        {
            int? cust_id = HttpContext.Session.GetInt32("cust_id");
            if (!cust_id.HasValue)
            {
                return RedirectToPage("/Login");
            }

            
            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.product_id == product_id && c.cust_id == cust_id.Value);

            if (existingCartItem != null)
            {
               
                TempData["Message"] = "Product is already in your cart!";
                return RedirectToPage("/Cart/customerCartDetails");
            }

           
            var cartDetails = new Data.Entity.Cart
            {
                product_id = product_id,
                cust_id = cust_id.Value,
            };

            _context.Carts.Add(cartDetails);
            _context.SaveChanges();
            return RedirectToPage("/Cart/customerCartDetails");
        }

        public IActionResult OnPostBuyNow(int product_id)
        {
            int? cust_id = HttpContext.Session.GetInt32("cust_id");
            if (!cust_id.HasValue)
            {
                return RedirectToPage("/Login");
            }

            var cartItem = new Data.Entity.Cart
            {
                product_id = product_id,
                cust_id = cust_id.Value,
                quantity = 1,
                is_buy_now = true
            };

            _context.Carts.Add(cartItem);
            _context.SaveChanges();

            return RedirectToPage("/Cart/BuyNow", new { product_id = product_id });
        }
    }
}



