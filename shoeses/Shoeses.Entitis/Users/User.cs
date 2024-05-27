using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shoeses.Entitis.Addresses;
using Shoeses.Entitis.Orders;
using Shoeses.Entitis.Reviews;
using Shoeses.Entitis.ShoppingCarts;

namespace Shoeses.Entitis.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }  // نام کوچک کاربر
        public string LastName { get; set; }  // نام خانوادگی کاربر
        public List<Address> Addresses { get; set; } = new();  // لیستی از آدرس‌های کاربر
        public List<Order> Orders { get; set; } = new();  // لیستی از سفارش‌های کاربر
        public List<Review> Reviews { get; set; } = new();  // لیستی از نقدهای کاربر
        public List<ShoppingCart> ShoppingCarts { get; set; } = new();  // لیستی از سبدهای خرید کاربر
    }
}
