using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
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

        public List<Product> prodtable { get; set; } = new List<Product>();


        public void OnGet()
        {

            prodtable = _context.producttable.ToList();
           
        }
    }
}
