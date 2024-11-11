using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace FarmCart.Pages.Supplier
{
    public class ViewProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ViewProductModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<Product> productlist { get; set; } 
        public void OnGet()
        {
            /*int? id = (int) HttpContext.Session.GetInt32("sup_id");
           productlist= _context.producttable.Where(p=>p.sup_id==id).ToList(); */
            int? id = HttpContext.Session.GetInt32("sup_id");
            if (id.HasValue)
            {
                productlist = _context.producttable.Where(p => p.sup_id == id.Value).ToList();
            }
            else
            {
                productlist = new List<Product>();
            }
        }
    
        public IActionResult OnPost(int product_id)
        {
            var product = _context.producttable.Find(product_id);
            if (product != null)
            {
                TempData["pid"] = product_id;
                return RedirectToPage("/Supplier/EditProduct");
            }
            return RedirectToPage();
           
        }
       
    }
}
