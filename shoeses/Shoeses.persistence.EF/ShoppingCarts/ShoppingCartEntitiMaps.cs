using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.persistence.EF.ShoppingCarts
{
    public class ShoppingCartEntitiMaps : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            // تنظیم کلید اصلی
            builder.HasKey(sc => sc.Id);

            // تنظیم فیلدهای ضروری
            builder.Property(sc => sc.UserId)
                .IsRequired();

            // تنظیم رابطه با User
            builder.HasOne(sc => sc.User)
                .WithMany(u => u.ShoppingCarts)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // تنظیم رابطه با ShoppingCartItem
            builder.HasMany(sc => sc.ShoppingCartItems)
                .WithOne(sci => sci.ShoppingCart)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);

            // تنظیم رابطه با Orders
            builder.HasMany(sc => sc.Orders)
                .WithOne(o => o.ShoppingCart)
                .HasForeignKey(o => o.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    
    }
}
