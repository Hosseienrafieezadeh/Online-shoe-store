using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Products;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.Services.Categoryes.Contracts.Dtos
{
    public class GetCategoryDto
    {
        public int Id { get; set; }  // شناسه یکتا برای دسته‌بندی
        public string Name { get; set; }  // نام دسته‌بندی
        public List<GetProductDto> Products { get; set; }=new ();
    }
}
