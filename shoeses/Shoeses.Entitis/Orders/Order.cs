using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Addresses;
using Shoeses.Entitis.OrderDetails;
using Shoeses.Entitis.Payments;
using Shoeses.Entitis.ShoppingCarts;
using Shoeses.Entitis.Users;

namespace Shoeses.Entitis.Orders
{
    public class Order
    {
        public int Id { get; set; }  // شناسه یکتا برای سفارش
        public DateTime OrderDate { get; set; }  // تاریخ ثبت سفارش
        public decimal TotalAmount { get; set; }  // مجموع مبلغ سفارش
        public string OrderStatus { get; set; }  // وضعیت سفارش (مثلاً در حال پردازش، ارسال شده و غیره)
        public string UserId { get; set; }  // شناسه کاربری که این سفارش متعلق به اوست

        public User User { get; set; }  // شیء کاربر مرتبط با این سفارش
        public List<OrderDetail> OrderDetails { get; set; } = new();  // لیستی از جزئیات سفارش

        // اضافه کردن خصوصیات مربوط به آدرس
        public int ShippingAddressId { get; set; }  // شناسه آدرس ارسال کالا
        public Address ShippingAddress { get; set; }  // شیء آدرس ارسال کالا
        // اضافه کردن رابطه با سبد خرید
        public int ShoppingCartId { get; set; }  // شناسه سبد خرید مرتبط
        public ShoppingCart ShoppingCart { get; set; }  // شیء سبد خرید مرتبط

        // اضافه کردن رابطه با پرداخت‌ها
        public List<Payment> Payments { get; set; } = new();  // لیستی از پرداخت‌های مرتبط با این سفارش
    }

}
