using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.Services.Products.Contracts
{
    public interface ProductService
    {
        Task Add(AddProductDto dto);
        Task Update(int id, UpdateProductDto dto);
        Task Delete(int id);
        Task<List<GetProductDto>> GetAll();
        Task<GetProductDto> GetById(int id);
    }
}
