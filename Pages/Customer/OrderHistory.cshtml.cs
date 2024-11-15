using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using System.Linq;
using FarmCart.Pages.Model;

namespace FarmCart.Pages.Customer
{
    public class OrderHistoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OrderHistoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<History> ord { get; set; } = new List<History>();

        [BindProperty]
        public feedback fe { get; set; }

        public void OnGet()
        {
            int? id = HttpContext.Session.GetInt32("cust_id");

            ord = (from o in _context.orderitemtable
                   join p in _context.producttable on o.product_id equals p.product_id
                   where o.cust_id == id
                   select new History
                   {
                       product_id = p.product_id,
                       product_name = p.product_name,
                       brand_name = p.brand_name,
                       product_price = p.product_price,
                       product_quantity = p.product_quantity,
                       product_description = p.product_description,
                       imagepath = p.imagepath,
                       item_ord_no = o.item_ord_no
                   }).ToList();
        }

        public IActionResult OnPost(int product_id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create a new Feedback object
            var feed = new Feedback
            {
                product_id = product_id,  // The product_id that was passed via the form
                feed_content = fe.feed_content,  // The feedback content from the form
                rating = fe.rating  // The rating selected from the form
            };

            // Add the feedback to the database
            _context.feedbacks.Add(feed);

           
            _context.SaveChanges();

           
            return RedirectToPage("/Index");
        }
    }
}
