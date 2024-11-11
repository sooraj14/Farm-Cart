using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;

namespace FarmCart.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CategoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

        public void OnGet(string categoryName)
        {
            CategoryName = categoryName;

            Products = _context.producttable
                .Where(p => p.product_name.Contains(categoryName))
                .ToList();
        }
    }
}
