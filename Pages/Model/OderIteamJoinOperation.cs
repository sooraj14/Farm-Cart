using FarmCart.Pages.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography;

namespace FarmCart.Pages.Model
{
    public class OderIteamJoinOperation
    {
        public int cust_id { get; set; }
        public int product_id { get; set; }
        public int product_price { get; set; }
        public int product_quantity { get; set; }
        public string product_name { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustPhone { get; set; }
    }
}

