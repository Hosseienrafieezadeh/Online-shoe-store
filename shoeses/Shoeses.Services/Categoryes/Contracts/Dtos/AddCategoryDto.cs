using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.Services.Categoryes.Contracts.Dtos
{
    public class AddCategoryDto
    {
        [Required]
        public string Name { get; set; }  // نام دسته‌بندی
     
        public  List<AddProductDto>? Products { get; set; }=new List<AddProductDto>();
    }
}
