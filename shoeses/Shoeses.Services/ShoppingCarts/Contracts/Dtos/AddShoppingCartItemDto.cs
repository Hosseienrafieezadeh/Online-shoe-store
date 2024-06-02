using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.ShoppingCarts.Contracts.Dtos
{
    public class AddShoppingCartItemDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
