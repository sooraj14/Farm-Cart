﻿using System.ComponentModel.DataAnnotations;

namespace FarmCart.Data.Entity
{
    public class Cart
    {
        [Key]
        public int cart_id { get; set; }
        public int product_id { get; set; }
        public int cust_id { get; set; }

        public int quantity { get; set; }
        public bool is_buy_now = true;
      /*  public Product Product { get; set; }*/

    }
}
