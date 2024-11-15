using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using System.Linq;

namespace FarmCart.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _context.producttable.FirstOrDefault(p => p.product_id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
        public IActionResult OnPostCart(int product_id)
        {
            int? customerId = HttpContext.Session.GetInt32("cust_id");
            if (customerId==null)
            {
                return RedirectToPage("/Customer/CustomerLogin");
            }

            var cartItem = _context.Carts.FirstOrDefault(c => c.cust_id == customerId && c.product_id == product_id);

            if (cartItem != null)
            {
                cartItem.quantity += 1;
            }
            else
            {
                _context.Carts.Add(new FarmCart.Data.Entity.Cart
                {
                    cust_id = customerId.Value,
                    product_id = product_id,
                    quantity = 1
                });

            }

            _context.SaveChanges();
            return RedirectToPage("/Cart/customerCartDetails");
        }


    }
}
