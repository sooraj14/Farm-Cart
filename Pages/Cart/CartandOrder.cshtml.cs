
using FarmCart.Pages.Model;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmCart.Pages.Cart
{  
    public class CartandOrderModel : PageModel
    {
        public readonly ApplicationDbContext _context;


        public CartandOrderModel(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }
        
        public CartDetails carstd { get; set; } = new CartDetails();
        public List<Product> prodlist { get; set; } = new List<Product>();
        public void OnGet(int product_id)
        {
            /*
                      var pr_id=       HttpContext.Session.SetInt32("addedProductId");*/
            /* var pid = TempData["ProductId"];*/
            var pid = TempData["ProductId"] ?? product_id;
            prodlist = _context.producttable.Where(p => p.product_id == (int)pid).ToList();
         
           




        }

        public IActionResult OnPostCart(int product_id)
        {
            int? cut_id = HttpContext.Session.GetInt32("cust_id");
            if (product_id == null)
            {

                return Page();
            }

            var carstdetails = new Data.Entity.Cart
            {
                cart_id = carstd.cart_id,
                product_id = product_id,
                cust_id = (int)cut_id,
                
            };
            _context.Carts.Add(carstdetails);
            _context.SaveChanges();
            return RedirectToPage("/Cart/customerCartDetails");
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