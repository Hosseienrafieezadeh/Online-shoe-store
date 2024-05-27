using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Users;

namespace Shoeses.Services.Addresses.Contracts.Dtos
{
    public class AddAdressDto
    {
       [Required]
        public string? UserId { get; set; }
        [Required]
        public string? Street { get; set; }  // نام خیابان
        [Required]
        public string? City { get; set; }  // نام شهر
        [Required]
        public string? State { get; set; }  // نام استان یا ایالت
        [Required]
        public string? PostalCode { get; set; }  // کد پستی
        [Required]
        public string? Country { get; set; }  // نام کشور
        [Required]
        public bool IsBillingAddress { get; set; }  // تعیین اینکه آیا آدرس برای صورتحساب است یا خیر
        [Required]
        public bool IsShippingAddress { get; set; }  // تعیین اینکه آیا آدرس برای ارسال کالا است یا خیر
     
    }
}
