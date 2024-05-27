using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shoeses.persistence.EF.Orders
{
    public class OrderEntityMaps :IEntityTypeConfiguration<Order>
    {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // تنظیم کلید اصلی
        builder.HasKey(o => o.Id);

        // تنظیم فیلدهای ضروری
        builder.Property(o => o.OrderDate).IsRequired();
        builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(o => o.OrderStatus).HasMaxLength(50).IsRequired();
        builder.Property(o => o.UserId).IsRequired();

        // تنظیم رابطه با User
        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // تنظیم رابطه با ShippingAddress
        builder.HasOne(o => o.ShippingAddress)
            .WithMany()
            .HasForeignKey(o => o.ShippingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        // تنظیم رابطه با BillingAddress
        //builder.HasOne(o => o.BillingAddress)
        //    .WithMany()
        //    .HasForeignKey(o => o.BillingAddressId)
        //    .OnDelete(DeleteBehavior.Restrict);

        // تنظیم رابطه با ShoppingCart
        builder.HasOne(o => o.ShoppingCart)
            .WithMany(sc => sc.Orders)
            .HasForeignKey(o => o.ShoppingCartId)
            .OnDelete(DeleteBehavior.Restrict);

        // تنظیم رابطه با Payments
        builder.HasMany(o => o.Payments)
            .WithOne(p => p.Order)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
}
