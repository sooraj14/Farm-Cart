namespace FarmCart.Pages.Model
{
    public class CartitemView
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public string Product_image { get; set; }
        public string Product_description { get; set; }
        public int Product_price { get; set; }
        public int Quantity { get; set; }
        public int Product_quantity { get; internal set; }
        public decimal Subtotal => Product_price * Quantity;

    }
}
