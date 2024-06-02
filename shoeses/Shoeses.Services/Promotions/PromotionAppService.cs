using Shoeses.Contracts.Interface;
using Shoeses.Entitis.Products;
using Shoeses.Entitis.Promotions;
using Shoeses.Services.Promotions.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Products.Contracts.Dtos;
using Shoeses.Services.Promotions.Contracts;

namespace Shoeses.Services.Promotions
{
   public class PromotionAppService:PromotionService
    {
        private readonly PromotionRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public PromotionAppService(PromotionRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddPromotionDto dto)
        {
            var promotion = new Promotion
            {
                Code = dto.Code,
                Description = dto.Description,
                DiscountAmount = dto.DiscountAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ApplicableProducts = dto.ApplicableProductIds.Select(id => new Product { Id = id }).ToList()
            };

            _repository.Add(promotion);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdatePromotionDto dto)
        {
            var promotion = _repository.Find(id);
            if (promotion == null)
                throw new KeyNotFoundException();

            promotion.Code = dto.Code;
            promotion.Description = dto.Description;
            promotion.DiscountAmount = dto.DiscountAmount;
            promotion.StartDate = dto.StartDate;
            promotion.EndDate = dto.EndDate;
            promotion.ApplicableProducts = dto.ApplicableProductIds.Select(id => new Product { Id = id }).ToList();

            _repository.Update(promotion);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var promotion = _repository.Find(id);
            if (promotion == null)
                throw new KeyNotFoundException();

            _repository.Delete(promotion);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetPromotionDto>> GetAll()
        {
            var promotions = await _repository.GetAll();
            return promotions.Select(p => new GetPromotionDto
            {
                Id = p.Id,
                Code = p.Code,
                Description = p.Description,
                DiscountAmount = p.DiscountAmount,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                ApplicableProducts = p.ApplicableProducts.Select(ap => new GetProductDto()
                {
                    Id = ap.Id,
                    Name = ap.Name
                }).ToList()
            }).ToList();
        }

        public async Task<GetPromotionDto> GetById(int id)
        {
            var promotion = _repository.Find(id);
            if (promotion == null)
                throw new KeyNotFoundException();

            return new GetPromotionDto
            {
                Id = promotion.Id,
                Code = promotion.Code,
                Description = promotion.Description,
                DiscountAmount = promotion.DiscountAmount,
                StartDate = promotion.StartDate,
                EndDate = promotion.EndDate,
                ApplicableProducts = promotion.ApplicableProducts.Select(ap => new GetProductDto()
                {
                    Id = ap.Id,
                    Name = ap.Name
                }).ToList()
            };
        }
    }
}
