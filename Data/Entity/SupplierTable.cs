using System.ComponentModel.DataAnnotations;

namespace FarmSquare.Data.Entity
{
    public class SupplierTable
    {
        [Key]
        public int sup_id { get; set; }
        public string sup_name { get; set; }
        public string sup_phone { get; set; }
        public string sup_email { get; set; }
        /*public string sup_location { get; set; }*/
        public string sup_password { get; set; }
        public string confirm_password { get; set; }
        public bool Is_Valid { get; set; }
    }
}
