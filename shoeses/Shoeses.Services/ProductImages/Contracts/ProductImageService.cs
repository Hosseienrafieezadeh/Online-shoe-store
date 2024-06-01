using Shoeses.Services.ProductImages.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.ProductImages.Contracts
{
    public interface ProductImageService
    {
        Task Add(AddProductImageDto dto);
        Task Update(int id, UpdateProductImageDto dto);
        Task Delete(int id);
        Task<List<GetProductImageDto>> GetAll();
    }
}
