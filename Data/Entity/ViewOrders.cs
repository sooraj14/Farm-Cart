using System.ComponentModel.DataAnnotations;

namespace FarmCart.Data.Entity
{
    public class ViewOrders
    {
        [Key]
        public int Id { get; set; }
        public int cust_id { get; set; }
        public int product_id { get; set; }
        public int product_price { get; set; }
        public int product_quantity { get; set; }
        public string product_name { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustPhone { get; set; }
    }
}
