using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Products;
using Shoeses.Entitis.Users;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Products.Contracts;
using Shoeses.Services.Products.Contracts.Dtos;
using Shoeses.Services.Promotions.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;

namespace Shoeses.persistence.EF.Products
{
    public class EFProductRepository:ProductRepository
    {
        private readonly EFDataContext _context;

        public EFProductRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public Product? Find(int Id)
        {
            return _context.Products.FirstOrDefault(_ => _.Id == Id);
        }

        public async Task<List<GetProductDto>> GetAll()
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Promotion)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews);

            List<GetProductDto> products = await query.Select(product => new GetProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId,
                PromotionId = product.PromotionId,
                Category = new GetCategoryDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                },
                Promotion = new GetPromotionDto
                {
                    Id = product.Promotion.Id,
                    Description = product.Promotion.Description
                },
                ProductImages = product.ProductImages.Select(image => new GetProductImageDto
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    ProductId = image.ProductId
                }).ToList(),
                Reviews = product.Reviews.Select(review => new GetReviewsDto
                {
                    Id = review.Id,
                    UserId = review.UserId,
                    ProductId = review.ProductId,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    ReviewDate = review.ReviewDate
                }).ToList()
            }).ToListAsync();

            return products;
        }

        public bool IsExistProduct(int id)
        {
            return _context.Products.Any(_ => _.Id == id);
        }

        public async Task<bool> IsExistPromotion(int id)
        {
            return await _context.Promotions.AnyAsync(_ => _.Id == id);
        }

        public async Task<bool> IsExsitCategoris(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> IsExistCategoryByName(string name)  // پیاده‌سازی متد بررسی وجود دسته‌بندی با نام خاص
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }
    }
}
