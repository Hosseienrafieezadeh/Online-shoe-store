using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoeses.Entitis.Categoryes;

namespace Shoeses.persistence.EF.Categoryes
{
    public class CategoryEntityMaps : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Define primary key
            builder.HasKey(c => c.Id);

            // Define properties
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            // Define navigation property
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // If a category is deleted, delete all associated products
        }
    }
}
