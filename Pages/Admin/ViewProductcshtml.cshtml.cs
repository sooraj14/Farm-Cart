using FarmSquare.Data.dbcontext;
using FarmSquare.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Admin
{
    
    public class ViewProductcshtmlModel : PageModel
    {
        public readonly ApplicationDbContext _context;

      
        public ViewProductcshtmlModel(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<Product> prod { get; set; }
        public void OnGet()
        {

            prod = _context.producttable.ToList();
        }
    }
}
