using FarmCart.Data.Entity;
using FarmSquare.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace FarmSquare.Data.dbcontext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomerTable> custtable { get; set; }
        public DbSet<SupplierTable> suptable { get; set; }
        public DbSet<Product> producttable { get; set; }
        public DbSet<Orders> ordertable { get; set; }
        public DbSet<OrderItem> orderitemtable { get; set; }
          
        public DbSet<Cart> carttable { get; set; }

        public DbSet<CustomerTable> Customers { get; set; }
        public DbSet<SupplierTable> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
