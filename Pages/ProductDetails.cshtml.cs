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
    }
}
