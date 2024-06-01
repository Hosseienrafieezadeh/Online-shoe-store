using Shoeses.Contracts.Interface;
using Shoeses.Entitis.ProductImages;
using Shoeses.Entitis.Products;
using Shoeses.Entitis.Reviews;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Products.Contracts.Dtos;
using Shoeses.Services.Products.Contracts;
using Shoeses.Services.Promotions.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Products.Contracts.Exeptions;
using Shoeses.Services.Categoryes.Contracts.Exeptions;

namespace Shoeses.Services.Products
{
    public class ProductAppService:ProductService
    {
        private readonly ProductRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public ProductAppService(ProductRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddProductDto dto)
        {
            if (!await _repository.IsExsitCategoris(dto.CategoryId))
                throw new CategoryNotFoundException();

            if (!await _repository.IsExistPromotion(dto.PromotionId))
                throw new PromotionNotFoundException();

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Count = dto.Count,
                CategoryId = dto.CategoryId,
                PromotionId = dto.PromotionId,
                ProductImages = dto.ProductImages.Select(pi => new ProductImage
                {
                    ImageUrl = pi.ImageUrl,
                    ProductId = pi.ProductId
                }).ToList(),
                Reviews = dto.Reviews.Select(r => new Review
                {
                    UserId = r.UserId,
                    ProductId = r.ProductId,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    ReviewDate = r.ReviewDate
                }).ToList()
            };

            _repository.Add(product);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateProductDto dto)
        {
            var product = _repository.Find(id);
            if (product == null)
                throw new ProductNotFoundExceptionToUpdate();

            if (!await _repository.IsExsitCategoris(dto.CategoryId))
                throw new CategoryNotFoundException();

            if (!await _repository.IsExistPromotion(dto.PromotionId))
                throw new PromotionNotFoundException();

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Count = dto.Count;
            product.CategoryId = dto.CategoryId;
            product.PromotionId = dto.PromotionId;

            _repository.Update(product);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var product = _repository.Find(id);
            if (product == null)
                throw new KeyNotFoundException();

            _repository.Delete(product);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetProductDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<GetProductDto> GetById(int id)
        {
            var product = _repository.Find(id);
            if (product == null)
                throw new ProductNotFoundException();

            return new GetProductDto
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
            };
        }
    }
}
