using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.persistence.EF.Promotions
{
    public class PromotionEntityMaps : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            // تنظیم کلید اصلی
            builder.HasKey(p => p.Id);

            // تنظیم فیلدهای ضروری
            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(255);

            builder.Property(p => p.DiscountAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            // تنظیم رابطه یک به چند با Product
            builder.HasMany(p => p.ApplicableProducts)
                .WithOne(p => p.Promotion)
                .HasForeignKey(p => p.PromotionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    
    }
}
