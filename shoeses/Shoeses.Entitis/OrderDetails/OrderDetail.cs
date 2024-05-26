using Shoeses.Entitis.Orders;
using Shoeses.Entitis.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.OrderDetails
{
    public class OrderDetail
    {
        public int Id { get; set; }  // شناسه یکتا برای جزئیات سفارش
        public int Quantity { get; set; }  // تعداد محصول سفارش داده شده
        public decimal UnitPrice { get; set; }  // قیمت واحد محصول در زمان سفارش
        public int OrderId { get; set; }  // شناسه سفارش مرتبط
        public Order Order { get; set; }  // شیء سفارش مرتبط
        public int ProductId { get; set; }  // شناسه محصول مرتبط
        public Product Product { get; set; } = new();  // شیء محصول مرتبط
    }
}
