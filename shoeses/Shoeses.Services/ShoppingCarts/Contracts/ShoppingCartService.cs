using Shoeses.Entitis.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.ShoppingCarts.Contracts.Dtos;

namespace Shoeses.Services.ShoppingCarts.Contracts
{
    public interface ShoppingCartService
    {
        Task Add(AddShoppingCartDto dto);
        Task Update(int id,UpdateShoppingCartDto dto);
        Task Delete(int id);
        Task<GetShoppingCartDto> GetById(int id);
        Task<List<GetShoppingCartDto> >GetAll();
    }
}
