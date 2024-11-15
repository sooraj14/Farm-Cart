using System.ComponentModel.DataAnnotations;

namespace FarmCart.Pages.Model
{
    public class myorder
    {
       
        public string product_name { get; set; }
        public int product_price { get; set; }
        public int product_quantity { get; set; }
        public bool send_delivery { get; set; }
        public int item_ord_no { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public string CustEmail { get; set; }

        public int sup_id { get; set; }
    }
}
