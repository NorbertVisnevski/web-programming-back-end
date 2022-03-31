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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Image>().ToTable("Image");

            modelBuilder.Entity<Role>().HasData(
                new { Name = "Admin" },
                new { Name = "Customer" }
                );

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("admin", out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new { Id = 1, Email = "admin@admin.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt }
                );


            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(e => e.ToTable("UserRole")
                .HasData(new { UsersId = 1, RolesName = "Admin" }));


        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

    }
}
