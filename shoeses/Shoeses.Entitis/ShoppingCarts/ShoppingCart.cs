using Shoeses.Entitis.Orders;
using Shoeses.Entitis.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.ShoppingCarts
{
    public class ShoppingCart
    {
        public int Id { get; set; }  // شناسه یکتا برای سبد خرید
        public string UserId { get; set; }  // شناسه کاربری که این سبد خرید متعلق به اوست
        public User User { get; set; }  // شیء کاربر مرتبط با این سبد خرید
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new();  // لیستی از اقلام موجود در سبد خرید

        // اضافه کردن رابطه با سفارش
        public List<Order> Orders { get; set; } = new List<Order>();  // لیستی از سفارش‌های مرتبط با این سبد خرید

    }
}
