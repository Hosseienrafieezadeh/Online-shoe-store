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
    public class ShoppingCartItemEntitiMaps : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            // تنظیم کلید اصلی
            // تنظیم کلید اصلی
            builder.HasKey(sci => sci.Id);

            // تنظیم رابطه با ShoppingCart
            builder.HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            // تنظیم رابطه با Product
            builder.HasOne(sci => sci.Product)
                .WithMany()
                .HasForeignKey(sci => sci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    
    }
}
