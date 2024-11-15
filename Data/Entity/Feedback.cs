using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmCart.Data.Entity
{
    public class Feedback
    {
        [Key]
        public int feed_id { get; set; }
        [ForeignKey("Product")]
        public int product_id { get; set; }
        public string feed_content { get; set; }
        public int rating { get; set; }
        public virtual Product Product { get; set; }
    }
}
