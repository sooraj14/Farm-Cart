using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using FarmCart.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace FarmCart.Pages.Supplier
{
    public class FeedbacksModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Sfeedback> Feedback { get; set; }

       
        public FeedbacksModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            int? feed = HttpContext.Session.GetInt32("sup_id");
            if (feed == null) 
            {
                return RedirectToPage("/Supplier/SupLogin");
            }

            Feedback = (from p in _context.producttable
                        join f in _context.feedbacks on p.product_id equals f.product_id
                        where p.sup_id == (int)feed
                        group f by new
                        {
                            p.product_id,
                            p.product_name,
                            p.imagepath
                        } into productGroup
                        select new Sfeedback
                        {
                            product_id = productGroup.Key.product_id,
                            product_name = productGroup.Key.product_name,
                            image = productGroup.Key.imagepath,
                           
                            AverageRating = productGroup.Average(f => f.rating), 
                                                                                  
                            Feedbacks = productGroup.Select(f => new Feedback
                            {
                                feed_content = f.feed_content,
                               /* rating = f.rating*/
                            }).ToList()
                        }).ToList();





            return Page();
        }
    }
}
