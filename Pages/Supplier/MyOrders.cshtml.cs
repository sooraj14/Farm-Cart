using FarmCart.Data.dbcontext;
using FarmCart.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmCart.Pages.Supplier
{
    public class MyOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<myorder> ords { get; set; } = new List<myorder>();
        public MyOrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            int? supp = HttpContext.Session.GetInt32("sup_id");
            if(supp == null)
            {
                return RedirectToPage("/Supplier/SupLogin");
            }

            ords = (from o in _context.orderitemtable
                    join p in _context.producttable
                    on o.product_id equals p.product_id
                    join c in _context.Customers
                  on o.cust_id equals c.CustId
                    where p.sup_id == (int)supp
                    select new myorder
                    {
                        product_name = p.product_name,
                        product_price = p.product_price,
                        product_quantity = o.product_quantity,
                        CustPhone = c.CustPhone,
                        CustEmail = c.CustEmail,
                        CustName = c.CustName,
                        item_ord_no = o.item_ord_no,
                        send_delivery = false
                    }).ToList();
                
               

            return Page();  
        }
    }
}
