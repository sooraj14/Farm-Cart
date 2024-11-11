using FarmCart.Data.Entity;
/*using FarmSquare.Data.Entity;*/
using Microsoft.EntityFrameworkCore;

namespace FarmCart.Data.dbcontext

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<CustomerTable> Customers { get; set; } //used in customer table
        public DbSet<SupplierTable> suptable { get; set; } //used 
        public DbSet<Product> producttable { get; set; } //used
        public DbSet<Orders> ordertable { get; set; }  
        public DbSet<OrderItem> orderitemtable { get; set; }
        public DbSet<Cart> Carts { get; set; }



        /*         public DbSet<CustomerTable> custtable { get; set; } // not required 
         public DbSet<SupplierTable> Suppliers { get; set; }
          public DbSet<Product> Products { get; set; }
          public DbSet<Orders> Orders { get; set; }
          public DbSet<OrderItem> OrderItems { get; set; }*/

        public object Categories { get; internal set; }
    }
}
