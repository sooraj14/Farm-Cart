using System.ComponentModel.DataAnnotations;

namespace FarmCart.Data.Entity
{
    public class Orders
    {
        [Key]
        public int ord_id { get; set; }
        public int ord_no { get; set; }
        public DateTime ord_date { get; set; }
        public int total_amount { get; set; }
        public string ord_address { get; set; }
        public int cust_id { get; set; }
        public string products { get; set; }
       /* public string? order_status { get; set; } = "Pending";

        // Navigation property
        public virtual ICollection<OrderItem> OrderItems { get; set; }*/

    }
}
