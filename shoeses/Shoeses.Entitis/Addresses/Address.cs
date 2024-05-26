using Shoeses.Entitis.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.Addresses
{
    /// <summary>
    /// مدیریت آدرس‌های کاربران برای صورتحساب و ارسال کالا.
    /// </summary>
    public class Address
    {
        public int Id { get; set; }  // شناسه یکتا برای آدرس
        public string UserId { get; set; }  // شناسه کاربری که این آدرس متعلق به اوست
        public User User { get; set; }  // شیء کاربر مربوط به این آدرس
        public string Street { get; set; }  // نام خیابان
        public string City { get; set; }  // نام شهر
        public string State { get; set; }  // نام استان یا ایالت
        public string PostalCode { get; set; }  // کد پستی
        public string Country { get; set; }  // نام کشور
        public bool IsBillingAddress { get; set; }  // تعیین اینکه آیا آدرس برای صورتحساب است یا خیر
        public bool IsShippingAddress { get; set; }  // تعیین اینکه آیا آدرس برای ارسال کالا است یا خیر
    }
}
