using Shoeses.Entitis.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.ProductImages
{
    public class ProductImage
    {
        public int Id { get; set; }  // شناسه یکتا برای تصویر محصول
        public string ImageUrl { get; set; }  // آدرس تصویر محصول
        public int ProductId { get; set; }  // شناسه محصول مرتبط
        public Product Product { get; set; }  // شیء محصول مرتبط
    }
}
