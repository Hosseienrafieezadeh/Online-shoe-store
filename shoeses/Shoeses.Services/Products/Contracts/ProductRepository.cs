using Shoeses.Entitis.Products;
using Shoeses.Entitis.Users;
using Shoeses.Services.Users.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.Services.Products.Contracts
{
    public interface ProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product? Find(int Id);
      
        Task<List<GetProductDto>> GetAll();
        bool IsExistProduct(int id);
        bool IsExistPromotion(int id);
       
    }
}
