using FarmCart.Data.dbcontext;
using FarmCart.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Admin
{
    public class ViewSuppliersModel : PageModel
    {
        
        public readonly ApplicationDbContext _context;


        public ViewSuppliersModel(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<SupplierTable> supplierTable { get; set; }

        public void OnGet()
        {
            supplierTable = _context.suptable.ToList();
        }

        public IActionResult OnPostDisable(int id, bool newstatus)
        {
            var supp = _context.suptable.Find(id);
            if (supp != null)
            {
                supp.Is_Valid = newstatus;
                _context.SaveChanges();
            }
            return RedirectToPage();
        }


        public IActionResult OnPostEnable(int id, bool newstatus)
        {
            var supp = _context.suptable.Find(id);
            if (supp != null)
            {
                supp.Is_Valid = newstatus;
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
    }

