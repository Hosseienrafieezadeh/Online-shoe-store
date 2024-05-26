using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Addresses;
using Shoeses.Entitis.Categoryes;
using Shoeses.Entitis.OrderDetails;
using Shoeses.Entitis.Orders;
using Shoeses.Entitis.Payments;
using Shoeses.Entitis.ProductImages;
using Shoeses.Entitis.Products;
using Shoeses.Entitis.Promotions;
using Shoeses.Entitis.Reviews;
using Shoeses.Entitis.ShoppingCarts;
using Shoeses.Entitis.Users;

namespace Shoeses.persistence.EF
{
    public class EFDataContext:IdentityDbContext<User>
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.UserId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.ShippingAddress)
            //    .WithMany()
            //    .HasForeignKey(o => o.ShippingAddressId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.BillingAddress)
            //    .WithMany()
            //    .HasForeignKey(o => o.BillingAddressId);

            //modelBuilder.Entity<Address>()
            //    .HasOne(a => a.User)
            //    .WithMany(u => u.Addresses)
            //    .HasForeignKey(a => a.UserId);

            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Order)
            //    .WithMany(o => o.OrderDetails)
            //    .HasForeignKey(od => od.OrderId);

            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Product)
            //    .WithMany()
            //    .HasForeignKey(od => od.ProductId);

            //// تنظیم رابطه بین ShoppingCart و Order
            //modelBuilder.Entity<ShoppingCart>()
            //    .HasMany(sc => sc.Orders)
            //    .WithOne(o => o.ShoppingCart)
            //    .HasForeignKey(o => o.ShoppingCartId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// تنظیم رابطه بین Product و ProductImage
            //modelBuilder.Entity<ProductImage>()
            //    .HasOne(pi => pi.Product)
            //    .WithMany(p => p.ProductImages)
            //    .HasForeignKey(pi => pi.ProductId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
