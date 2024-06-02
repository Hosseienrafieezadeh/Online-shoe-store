using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.ShoppingCarts.Contracts.Dtos
{
    public class UpdateShoppingCartDto
    {
        public string UserId { get; set; }
        public List<UpdateShoppingCartItemDto> ShoppingCartItems { get; set; } = new();
    }
}
