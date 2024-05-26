using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoeses.Entitis.Payments;

namespace Shoeses.persistence.EF.Payments
{
    public class PaymentEntityMaps:IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // تنظیم کلید اصلی
            builder.HasKey(p => p.Id);

            // تنظیم طول حداکثری برای فیلد PaymentMethod
            builder.Property(p => p.PaymentMethod)
                .HasMaxLength(50)
                .IsRequired();

            // تنظیم نوع و دقت برای فیلد Amount
            builder.Property(p => p.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // تنظیم رابطه با Order
            builder.HasOne(p => p.Order)
                .WithMany(o => o.Payments) // فرض بر این است که کلاس Order دارای یک مجموعه Payments است
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // سایر تنظیمات مورد نیاز را اینجا انجام دهید
        }
    }
}
