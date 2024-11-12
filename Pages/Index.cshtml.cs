using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }
        public CustomerTable cust { get; set; }
       /* private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
*/
        public void OnGet()
        {
            Products = _context.producttable.ToList();


        }
        /* public  IActionResult OnPost(int id)
         {

           int?  customer_id=  HttpContext.Session.GetInt32("cust_id");

             var product =  _context.producttable.Find(id);

           *//*  HttpContext.Session.SetInt32("product_id", product.product_id);*//*

             if(customer_id == null)
             {
                 return RedirectToPage("CustomerLogin");
             }
             else
             {
                 return RedirectToPage("CartandOrder");
             }
             if (product == null)
             {
                 return NotFound();
             }

             return RedirectToPage("CustomerLogin"); // Reload the page after deletion
         }*/

        /*   public IActionResult OnPost(int id)
           {
               // Find the product by ID
               var product = _context.producttable.Find(id);

               if (product == null)
               {
                   return NotFound(); // Product not found
               }

               int? customer_id = HttpContext.Session.GetInt32("cust_id");

               if (customer_id == null)
               {
                   return RedirectToPage("CustomerLogin"); // Redirect if customer is not logged in
               }
               else
               {
                   return RedirectToPage("CartandOrder"); // Redirect if customer is logged in
               }
           }*/


        public IActionResult OnPost(int productId)
        {
            var product = _context.producttable.Find(productId);

            if (product == null)
            {
                return NotFound(); 
            }

            int? customer_id = HttpContext.Session.GetInt32("cust_id");

            if (customer_id == null)
            {
                return RedirectToPage("/Customer/CustomerLogin"); 
            }


            TempData["ProductID"] = productId;
            return RedirectToPage("/Cart/CartandOrder");

        }


    }
}
