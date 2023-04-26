using Detyre_KursiAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Detyre_KursiAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(am => new
            {
                am.PorosiId,
                am.ProduktId
            });
            modelBuilder.Entity<OrderDetails>().HasOne(m => m.product).WithMany(am => am.orderDetails).HasForeignKey(m => m.ProduktId);
            modelBuilder.Entity<OrderDetails>().HasOne(m => m.order).WithMany(am => am.orderDetails).HasForeignKey(m => m.PorosiId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}