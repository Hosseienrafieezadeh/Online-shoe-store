using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shoeses.persistence.EF.Addresses
{
    public class AddressEntityMaps : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // نام جدول
            builder.ToTable("Addresses");

            // تنظیم کلید اصلی
            builder.HasKey(a => a.Id);

            // تعیین روابط و کلیدهای خارجی
            builder.HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade); // یا Restrict، یا NoAction بسته به نیاز شما

            // تنظیم دیگر ویژگی‌ها
            builder.Property(a => a.Street).IsRequired().HasMaxLength(100);
            builder.Property(a => a.City).IsRequired().HasMaxLength(50);
            builder.Property(a => a.State).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PostalCode).IsRequired().HasMaxLength(20);
            builder.Property(a => a.Country).IsRequired().HasMaxLength(50);
            builder.Property(a => a.IsBillingAddress).IsRequired();
            builder.Property(a => a.IsShippingAddress).IsRequired();
        }
    }
}
