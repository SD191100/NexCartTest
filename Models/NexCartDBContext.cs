using Microsoft.EntityFrameworkCore;

namespace NexCart.Models
{
    public class NexCartDBContext : DbContext
    {
        public NexCartDBContext() { }
        public NexCartDBContext(DbContextOptions<NexCartDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<>().HasData(
            //    new Employee() { EmployeeId = 1, EmployeeName = "Anup", EmployeeEmail = "anup@gmail.com", EmployeePhone = "2233445" },
            //    new Employee() { EmployeeId = 2, EmployeeName = "Ayush", EmployeeEmail = "Ayush@gmail.com", EmployeePhone = "3344556" }
            //    );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> SellerDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
