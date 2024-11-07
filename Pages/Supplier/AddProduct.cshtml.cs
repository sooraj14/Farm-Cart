using FarmCart.Pages.Model;
using FarmSquare.Data.dbcontext;
using FarmSquare.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Supplier
{
    public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AddProductModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }
        [BindProperty]
        public ProductAdd newproduct { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            int? Id = HttpContext.Session.GetInt32("sup_id");
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(newproduct.imagefile.FileName);
            string filepath = Path.Combine(_environment.WebRootPath, "Images", filename);
            var filestream = new FileStream(filepath, FileMode.Create);
            await newproduct.imagefile.CopyToAsync(filestream);
            var product = new Product
            {
                product_name = newproduct.product_name,
                brand_name = newproduct.brand_name,
                product_description = newproduct.product_description,
                product_price = newproduct.product_price,
                product_quantity = newproduct.product_quantity,
                imagepath= filename,
                sup_id = (int)Id
            };
            await _context.producttable.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToPage("ViewProduct");
        }
    }
}
