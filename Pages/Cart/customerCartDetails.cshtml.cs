using FarmCart.Pages.Model;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

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

        public List<Orders> ordertabledetails { get; set; } = new List<Orders>();
        public void OnGet()
        {

            int? cut_id = HttpContext.Session.GetInt32("cust_id");
           
          OrderProduct = _context.Carts.Where(cart => cart.cust_id == cut_id).Join(_context.producttable, cart => cart.product_id,
                product => product.product_id, (cart, product) => new OrderProductJoin
                {
                    Product_description = product.product_description,
                    Product_id = product.product_id,
                    Product_name = product.product_name,
                    Product_image= product.imagepath,
                    Product_price= product.product_price,
                    Product_quantity= product.product_quantity
                } 
              
              ).ToList();
          
        }
        public IActionResult OnPostPlaceOrder(int product_id)
        {

           
            return RedirectToPage("/OrderPlaced");
        }
    }
}

