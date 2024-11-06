﻿using System.ComponentModel.DataAnnotations;

namespace FarmSquare.Data.Entity
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
    }
}
