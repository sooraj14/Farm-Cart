using FarmSquare.Data.dbcontext;
using FarmSquare.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Admin
{
    public class ViewOrdersModel : PageModel
    {

        public readonly ApplicationDbContext _context;



        public ViewOrdersModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<Orders> ord { get; set; }
        public void OnGet()
        {
            ord = _context.ordertable.ToList();
        }
    }
}
