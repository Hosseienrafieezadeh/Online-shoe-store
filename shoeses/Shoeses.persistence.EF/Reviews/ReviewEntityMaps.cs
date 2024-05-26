using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.persistence.EF.Reviews
{
    public class ReviewEntityMaps : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // تنظیم کلید اصلی
            builder.HasKey(r => r.Id);

            // تنظیم فیلدهای ضروری
            builder.Property(r => r.UserId)
                .IsRequired();

            builder.Property(r => r.ProductId)
                .IsRequired();

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.ReviewDate)
                .IsRequired();

            // تنظیم رابطه با User
            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // تنظیم رابطه با Product
            builder.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    
    }
}
