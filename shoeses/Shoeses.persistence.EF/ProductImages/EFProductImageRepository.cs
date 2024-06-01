using Shoeses.Entitis.ProductImages;
using Shoeses.Services.ProductImages.Contracts;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shoeses.persistence.EF.ProductImages
{
    public class EFProductImageRepository: ProductImageRepository
    {
        private readonly EFDataContext _context;

        public EFProductImageRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
        }

        public void Update(ProductImage productImage)
        {
            _context.ProductImages.Update(productImage);
        }

        public void Delete(ProductImage productImage)
        {
            _context.ProductImages.Remove(productImage);
        }

        public ProductImage Find(int id)
        {
            return _context.ProductImages.FirstOrDefault(pi => pi.Id == id);
        }

        public async Task<List<GetProductImageDto>> GetAll()
        {
            return await _context.ProductImages.Select(pi => new GetProductImageDto
            {
                Id = pi.Id,
                ImageUrl = pi.ImageUrl,
                ProductId = pi.ProductId
            }).ToListAsync();
        }

        public async Task<bool> IsExsitedProduct(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }
    }
}
