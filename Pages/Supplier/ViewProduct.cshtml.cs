using FarmSquare.Data.dbcontext;
using FarmSquare.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            productlist = _context.producttable.ToList();
        }
    }
}
