using Shoeses.Entitis.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.ShoppingCarts.Contracts.Dtos;

namespace Shoeses.Services.ShoppingCarts.Contracts
{
    public interface ShoppingCartRepository
    {
        void Add(ShoppingCart cart);
        void Update(ShoppingCart cart);
        void Delete(ShoppingCart cart);
        Task<GetShoppingCartDto> GetById(int id);
        Task<List<GetShoppingCartDto>> GetAll();
        ShoppingCart? Find(int Id);
    }
}
