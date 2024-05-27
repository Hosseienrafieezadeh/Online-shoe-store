using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Addresses.Contracts.Dtos
{
    public class GetAdressDto
    {
        public int Id { get; set; }  // شناسه یکتا برای آدرس
        public string? UserId { get; set; }  // شناسه کاربری که این آدرس متعلق به اوست
        public string? Street { get; set; }  // نام خیابان
        public string? City { get; set; }  // نام شهر
        public string? State { get; set; }  // نام استان یا ایالت
        public string? PostalCode { get; set; }  // کد پستی
        public string? Country { get; set; }  // نام کشور
        public bool IsBillingAddress { get; set; }  // تعیین اینکه آیا آدرس برای صورتحساب است یا خیر
        public bool IsShippingAddress { get; set; }  // تعیین اینکه آیا آدرس برای ارسال کالا است یا خیر
    }
}
