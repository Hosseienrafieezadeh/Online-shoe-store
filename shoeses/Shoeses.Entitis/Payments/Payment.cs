using Shoeses.Entitis.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.Payments
{
    /// <summary>
    /// ذخیره اطلاعات پرداخت برای سفارش‌ها.
    /// </summary>
    public class Payment
    {
        public int Id { get; set; }  // شناسه یکتا برای پرداخت
        public string PaymentMethod { get; set; }  // روش پرداخت (مثلاً کارت اعتباری، پی پال و غیره)
        public decimal Amount { get; set; }  // مبلغ پرداختی
        public DateTime PaymentDate { get; set; }  // تاریخ پرداخت
        public int OrderId { get; set; }  // شناسه سفارش مرتبط
        public Order Order { get; set; }  // شیء سفارش مرتبط
    }
}
