using System.ComponentModel.DataAnnotations;

namespace FarmCart.Data.Entity
{
    public class OrderItem
    {
        [Key]
        public int item_id { get; set; }
        public int item_ord_no { get; set; }
        public int cust_id { get; set; }
        public int product_id { get; set; }
        public int product_price { get; set; }
        public int product_quantity { get; set; }

        public bool Is_Available { get; set; }
        public decimal subtotal => product_price * product_quantity;

        // Navigation properties
     /*   public virtual Orders Order { get; set; }*/
    }
}
