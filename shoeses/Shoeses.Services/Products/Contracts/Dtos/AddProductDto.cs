using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Products.Contracts.Dtos
{
   public class AddProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int PromotionId { get; set; }
        public List<AddProductImageDto> ProductImages { get; set; } = new();
        public List<AddReviewDto> Reviews { get; set; } = new();
    }
}
