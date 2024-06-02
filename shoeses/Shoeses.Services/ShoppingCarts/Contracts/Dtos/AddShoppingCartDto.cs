using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.ShoppingCarts.Contracts.Dtos
{
   public class AddShoppingCartDto
    {
        public string UserId { get; set; }
        public List<AddShoppingCartItemDto> ShoppingCartItems { get; set; } = new();
    }
}
