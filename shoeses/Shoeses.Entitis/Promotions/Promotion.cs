using Shoeses.Entitis.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.Promotions
{
    public class Promotion
    {
        public int Id { get; set; }  // شناسه یکتا برای پروموشن
        public string Code { get; set; }  // کد تخفیف یا پروموشن
        public string Description { get; set; }  // توضیحات پروموشن
        public decimal DiscountAmount { get; set; }  // مبلغ تخفیف
        public DateTime StartDate { get; set; }  // تاریخ شروع پروموشن
        public DateTime EndDate { get; set; }  // تاریخ پایان پروموشن
        public List<Product> ApplicableProducts { get; set; } = new();  // لیستی از محصولات که این پروموشن به آنها اعمال می‌شود

    }
}
