using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoeses.Entitis.OrderDetails;

namespace Shoeses.persistence.EF.OrderDetails
{
    public class OrderDetailEntityMaps:IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // Define primary key
            builder.HasKey(od => od.Id);

            // Define properties
            builder.Property(od => od.Quantity).IsRequired();
            builder.Property(od => od.UnitPrice).HasColumnType("decimal(18, 2)").IsRequired();

            // Define foreign keys and relationships
            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // If an order is deleted, delete all associated order details

            builder.HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // If a product is deleted, set ProductId to null
        }
    }
}
