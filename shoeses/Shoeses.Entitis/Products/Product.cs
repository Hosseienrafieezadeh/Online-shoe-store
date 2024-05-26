using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Categoryes;
using Shoeses.Entitis.ProductImages;
using Shoeses.Entitis.Promotions;
using Shoeses.Entitis.Reviews;

namespace Shoeses.Entitis.Products
{
    public class Product
    {
        public int Id { get; set; }  // شناسه یکتا برای محصول
        public string Name { get; set; }  // نام محصول
        public string Description { get; set; }  // توضیحات محصول
        public decimal Price { get; set; }  // قیمت محصول
        public int Count { get; set; }  // تعداد موجودی محصول
        public int CategoryId { get; set; }  // شناسه دسته‌بندی محصول
        public int PromotionId { get; set; }  // شناسه پروموشن مرتبط

        public Category Category { get; set; }  // شیء دسته‌بندی مرتبط با محصول
        public Promotion Promotion { get; set; }  // شیء پروموشن مرتبط با محصول
        public List<ProductImage> ProductImages { get; set; } = new();  // لیستی از تصاویر محصول
        public List<Review> Reviews { get; set; }
    }

}
