using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.ProductImages;
using Shoeses.Entitis.Reviews;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Promotions.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;

namespace Shoeses.Services.Products.Contracts.Dtos
{
   public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public int PromotionId { get; set; }
        public GetCategoryDto Category { get; set; }
        public GetPromotionDto Promotion { get; set; }
        public List<GetProductImageDto> ProductImages { get; set; }
        public List<GetReviewsDto> Reviews { get; set; }

    }
}
