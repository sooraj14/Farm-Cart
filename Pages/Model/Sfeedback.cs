using FarmCart.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FarmCart.Pages.Model
{
    public class Sfeedback
    {
        
        public string feed_content { get; set; }
        public int rating { get; set; }
        public string product_name { get; set; }
        public string image { get; set; }

        [Key]
        public int product_id { get; set; }

        public double AverageRating { get; set; }

        public List<Feedback> Feedbacks { get; set; }

    }
}
