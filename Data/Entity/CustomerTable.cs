using System.ComponentModel.DataAnnotations;

namespace FarmSquare.Data.Entity
{
    public class CustomerTable
    {
        [Key]
        public int cust_id {  get; set; }
        public string cust_name { get; set; }
        public string cust_phone { get; set; }
        public string cust_email { get; set; }
        public string cust_password { get; set; }
        public string confirm_password { get; set; }
        public bool Is_Active { get; set; }
    }
}
