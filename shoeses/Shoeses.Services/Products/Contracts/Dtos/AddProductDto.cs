using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Products.Contracts.Dtos
{
   public class AddProductDto
    {
        
        public string Name { get; set; }  // نام محصول
        public string Description { get; set; }  // توضیحات محصول
        public decimal Price { get; set; }  // قیمت محصول
        public int Count { get; set; }  // تعداد موجودی محصول
        public int CategoryId { get; set; }  // شناسه دسته‌بندی محصول
        public int PromotionId { get; set; }
    }
}
