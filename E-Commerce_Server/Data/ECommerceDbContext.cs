using Microsoft.EntityFrameworkCore;
using E_Commerce_Server.Models;

namespace E_Commerce_Server.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Receipt> Receipts { get; set; } = null!;
        public DbSet<Ship> Ships { get; set; } = null!;
        public DbSet<ShipInfo> ShipInfos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.SellerId).IsRequired();
            });

            // Cart configuration
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
            });

            // Payment configuration
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
            });

            // Receipt configuration
            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CartId).IsRequired();
                entity.Property(e => e.BankId).IsRequired();
                entity.Property(e => e.PaymentId).IsRequired();
                entity.Property(e => e.PaymentStatus).IsRequired();
            });

            // Ship configuration
            modelBuilder.Entity<Ship>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
            });

            // ShipInfo configuration
            modelBuilder.Entity<ShipInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ReceiptId).IsRequired();
                entity.Property(e => e.SellerId).IsRequired();
                entity.Property(e => e.ShipId).IsRequired();
                entity.Property(e => e.DeliveryStatus).IsRequired();
                entity.Property(e => e.TrackingNumber).HasMaxLength(100);
            });
        }
    }
}