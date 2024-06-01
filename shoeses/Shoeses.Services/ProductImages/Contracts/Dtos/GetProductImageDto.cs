using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.ProductImages.Contracts.Dtos
{
    public class GetProductImageDto
    {
        public int Id { get; set; }  // شناسه یکتا برای تصویر محصول
        public string ImageUrl { get; set; }  // آدرس تصویر محصول
        public int ProductId { get; set; }  // شناسه محصول مرتبط
    }
}
