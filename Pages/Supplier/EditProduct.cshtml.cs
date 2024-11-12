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
    public   class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditProductModel(ApplicationDbContext context)
        {
            _context = context;
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
                    product_id= newuser.product_id
                };
            }
            return Page();
            
        }  

        public IActionResult OnPost()
        {

         
            var newuser = _context.producttable.Find(editdata.product_id);

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
                     
                }

               
                _context.SaveChanges();
              
                  return RedirectToPage("/Supplier/SupHome");
        }
    }
}
