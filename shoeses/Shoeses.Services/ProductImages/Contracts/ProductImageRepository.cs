using Shoeses.Entitis.ProductImages;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Products;

namespace Shoeses.Services.ProductImages.Contracts
{
    public interface ProductImageRepository
    {
        void Add(ProductImage productImage);
        void Update(ProductImage productImage);
        void Delete(ProductImage productImage);
        ProductImage Find(int id);
        Task<List<GetProductImageDto>> GetAll();
        Task<bool> IsExsitedProduct(int id);
    }
}
