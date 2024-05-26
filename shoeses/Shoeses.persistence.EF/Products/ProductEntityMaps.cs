using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shoeses.persistence.EF.Products
{
    public class ProductEntityMaps : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Define primary key
            builder.HasKey(p => p.Id);

            // Define properties
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(p => p.Count).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();

            // Define foreign key
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // If a product's category is deleted, set CategoryId to null

            // Define navigation property
            builder.HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // If a product is deleted, delete all associated product images
            // تنظیم رابطه یک به چند با Promotion
            builder.HasOne(p => p.Promotion)
                .WithMany(p => p.ApplicableProducts)
                .HasForeignKey(p => p.PromotionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
