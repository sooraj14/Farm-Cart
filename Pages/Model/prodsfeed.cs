using FarmCart.Data.Entity;

namespace FarmCart.Pages.Model
{
    public class prodsfeed
    {


        /* public int product_id { get; set; }
         public string product_name { get; set; }
         public string brand_name { get; set; }
         public string product_description { get; set; }
         public int product_price { get; set; }
         public int product_quantity { get; set; }

         public string imagepath { get; set; }   
         public string feed_content { get; set; }
         public int rating { get; set; }*/
        public Product Product { get; set; }
        public List<Feedback> Prodsfeed { get; set; } = new List<Feedback>();

    }
}
