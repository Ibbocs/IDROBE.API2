using IDROBE.API.Entities.Identity;
using IDROBE.API.Entities.Main;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IDROBE.API.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
           .Property(p => p.Price)
           .HasColumnType("decimal(18,13)");

            builder.Entity<Order>()
           .Property(p => p.TotalAmount)
           .HasColumnType("decimal(18,5)");

            builder.Entity<OrderDetails>()
           .Property(p => p.Subtotal)
           .HasColumnType("decimal(18,5)");


            builder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);
              //.OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
              //.OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
