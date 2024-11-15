using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using FarmCart.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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

            // Check if the product is already in the cart
            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.product_id == product_id && c.cust_id == cust_id.Value);

            if (existingCartItem != null)
            {
                // Product already in the cart, show a message
                TempData["Message"] = "Product is already in your cart!";
                return RedirectToPage("/Cart/customerCartDetails");
            }

            // If not, add it to the cart
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
                return RedirectToPage("/Index");
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




/*public IActionResult OnPostCart(int product_id, int quantity)
{
    // Retrieve customer ID from session
    int? cut_id = HttpContext.Session.GetInt32("cust_id");

    // Ensure that a valid customer ID is retrieved
    if (cut_id == null)
    {
        return RedirectToPage("/Account/Login");  // Or handle session-related issues as per your app's flow
    }

    // Check if the product_id exists in the producttable
    var product = _context.producttable.FirstOrDefault(p => p.product_id == product_id);
    if (product == null)
    {
        TempData["ErrorMessage"] = "Product not found.";
        return RedirectToPage("/Error");  // Handle the error gracefully
    }

    // Create the Cart entity to add
    var carstdetails = new Data.Entity.Cart
    {
        product_id = product_id,
        cust_id = (int)cut_id,
        quantity = quantity  // Use the quantity parameter passed to the method
    };

    // Add the new Cart item to the database
    _context.Carts.Add(carstdetails);
    _context.SaveChanges();

    // Redirect to customer cart details page after successfully adding the product to the cart
    return RedirectToPage("/Cart/customerCartDetails");
}*/