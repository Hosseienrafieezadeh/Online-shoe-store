using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Products.Contracts.Dtos
{
    public class UpdateProductDto
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
    }
}
