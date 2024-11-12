using FarmCart.Pages.Model;
using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FarmCart.Pages.Supplier
{
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public EditProductModel(ApplicationDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        
        [BindProperty]
        public EditProduct editdata { get; set; }

       
        public IActionResult OnGet(int? product_id)
        {
            if (!product_id.HasValue)
            {
                product_id = (int?)TempData["pid"];
            }

            if (!product_id.HasValue)
            {
                return NotFound();
            }
            var newuser = _context.producttable.Find(product_id);
            int? Id = HttpContext.Session.GetInt32("sup_id");
            if (newuser == null)
            {
                return NotFound();
            }
            else
            {
                
                editdata = new EditProduct
                {
                    product_name = newuser.product_name,
                    brand_name = newuser.brand_name,
                    product_description = newuser.product_description,
                    product_price = newuser.product_price,
                    product_quantity = newuser.product_quantity, 
                    product_id= newuser.product_id,
                    image_url = newuser.imagepath

                };
            }
            return Page();
            
        }  

        public async Task<IActionResult> OnPostAsync()
        {         

            var newuser = _context.producttable.Find(editdata.product_id);
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(editdata.imagefile.FileName);
            string filepath = Path.Combine(_environment.WebRootPath, "Images", filename);
            var filestream = new FileStream(filepath, FileMode.Create);
            await editdata.imagefile.CopyToAsync(filestream);

            if (newuser == null)
                {
                    return NotFound();
                }
                else
                {                
                    newuser.product_name = editdata.product_name;
                    newuser.brand_name = editdata.brand_name;
                    newuser.product_description = editdata.product_description;
                    newuser.product_price = editdata.product_price;
                    newuser.product_quantity = editdata.product_quantity;
                    newuser.imagepath = filename;
                     
                }

                   await _context.SaveChangesAsync();
                  return RedirectToPage("/Supplier/SupHome");
        }
    }
}
