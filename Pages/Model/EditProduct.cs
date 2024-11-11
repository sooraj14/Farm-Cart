using Microsoft.AspNetCore.Mvc;

namespace FarmCart.Pages.Model
{
        public class EditProduct
        {
        public int product_id { get; set; }
            public string product_name { get; set; }
            public string brand_name { get; set; }
            public string product_description { get; set; }
            public int product_price { get; set; }
            public int product_quantity { get; set; }
            public int sup_id { get; set; }
            public IFormFile imagefile { get; set; }
        }
    }
