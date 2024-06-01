using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.ProductImages.Contracts.Dtos
{
    public class AddProductImageDto
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
