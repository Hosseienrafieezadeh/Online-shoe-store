using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.ShoppingCarts.Contracts;
using Shoeses.Services.ShoppingCarts.Contracts.Dtos;
using Shoeses.Services.Users.Contracts.Dtos;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.persistence.EF.ShoppingCarts
{
    public class EFShoppingCartRepository : ShoppingCartRepository
    {
        private readonly EFDataContext _context;

        public EFShoppingCartRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(ShoppingCart cart)
        {
            _context.ShoppingCarts.Add(cart);
        }

        public void Update(ShoppingCart cart)
        {
            _context.ShoppingCarts.Update(cart);
        }

        public void Delete(ShoppingCart cart)
        {
            _context.ShoppingCarts.Remove(cart);
        }

        public async  Task<GetShoppingCartDto> GetById(int id)
        {
            var cart = await _context.ShoppingCarts
                .Include(c => c.User)
                .Include(c => c.ShoppingCartItems)
                .ThenInclude(sci => sci.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            return MapToDto(cart);
        }


        public async Task<List<GetShoppingCartDto>> GetAll()
        {
            IQueryable<ShoppingCart> query = _context.ShoppingCarts;
            List<GetShoppingCartDto> shoppingCarts = await query.Select(cart => new GetShoppingCartDto()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                ShoppingCartItems = _context.ShoppingCartItems
                    .Where(item => item.ShoppingCartId == cart.Id)
                    .Select(item => new GetShoppingCartItemDto()
                    {
                        Id = item.Id,
                        Quantity = item.Quantity,
                        ProductId = item.ProductId,
                        Product = _context.Products
                            .Where(p => p.Id == item.ProductId)
                            .Select(p => new GetProductDto()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                Price = p.Price
                            }).FirstOrDefault()
                    }).ToList()
            }).ToListAsync();

            return shoppingCarts;
        }

        public ShoppingCart? Find(int Id)
        {
            return _context.ShoppingCarts.FirstOrDefault(_ => _.Id == Id);
        }
    
    private GetShoppingCartDto MapToDto(ShoppingCart cart)
    {
        if (cart == null)
            return null;

        return new GetShoppingCartDto
        {
            Id = cart.Id,
            UserId = cart.UserId,
            ShoppingCartItems = cart.ShoppingCartItems.Select(item => new GetShoppingCartItemDto
            {
                Id = item.Id,
                Quantity = item.Quantity,
                ProductId = item.ProductId,
                Product = new GetProductDto
                {
                    Id = item.Product.Id,
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Price = item.Product.Price
                }
            }).ToList()
        };
        }

    }
}
