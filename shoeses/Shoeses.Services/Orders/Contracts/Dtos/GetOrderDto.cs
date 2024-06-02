using Shoeses.Services.Addresses.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.OrderDetails.Contracts.Dtos;
using Shoeses.Services.Users.Contracts.Dtos;
using Shoeses.Services.ShoppingCarts.Contracts.Dtos;

namespace Shoeses.Services.Orders.Contracts.Dtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string UserId { get; set; }
        public GetUserDto User { get; set; }
        public int ShippingAddressId { get; set; }
        public GetAdressDto ShippingAddress { get; set; }
        public int ShoppingCartId { get; set; }
        public GetShoppingCartDto ShoppingCart { get; set; }
        public List<GetOrderDetailDto> OrderDetails { get; set; }
    }
}
