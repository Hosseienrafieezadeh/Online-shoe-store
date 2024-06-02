using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Users.Contracts.Dtos;

namespace Shoeses.Services.ShoppingCarts.Contracts.Dtos
{
   public class GetShoppingCartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        
        public List<GetShoppingCartItemDto> ShoppingCartItems { get; set; }
    }
}
