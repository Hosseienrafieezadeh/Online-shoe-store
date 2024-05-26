using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.ProductImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.persistence.EF.ProductImages
{
    public class ProductImageEntityMaps : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // تنظیم کلید اصلی
            builder.HasKey(pi => pi.Id);

            // تنظیم فیلدهای ضروری
            builder.Property(pi => pi.ImageUrl)
                .IsRequired()
                .HasMaxLength(255);

            // تنظیم رابطه با Product
            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
    
}
