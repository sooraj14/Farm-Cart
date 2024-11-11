using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmCart.Data.Entity
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string brand_name { get; set; }
        public string product_description { get; set; }
        public int product_price { get; set; }
        public int product_quantity { get; set; }
        public int sup_id { get; set; }
        public string imagepath { get; set; }
        
        public bool is_available { get; set; }


    }
}
