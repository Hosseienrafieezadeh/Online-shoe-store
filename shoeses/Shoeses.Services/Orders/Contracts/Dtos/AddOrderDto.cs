using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.OrderDetails.Contracts.Dtos;

namespace Shoeses.Services.Orders.Contracts.Dtos
{
    public class AddOrderDto
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int ShippingAddressId { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }

        public List<AddOrderDetailDto> OrderDetails { get; set; }
    }
}
