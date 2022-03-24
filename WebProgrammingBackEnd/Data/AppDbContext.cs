using Microsoft.EntityFrameworkCore;
using WebProgrammingBackEnd.Entities;

namespace WebProgrammingBackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SubOrder> SubOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<SubOrder>().ToTable("SubOrder");

            modelBuilder
                .Entity<Category>()
                .HasAlternateKey(c => c.Name);

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.ToTable("ProductCategory"));
        }

    }
}
