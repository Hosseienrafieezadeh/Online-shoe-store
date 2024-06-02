using Shoeses.Entitis.ShoppingCarts;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Products.Contracts.Dtos;
using Shoeses.Services.Promotions.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;
using Shoeses.Services.ShoppingCarts.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Contracts.Interface;
using Shoeses.Services.ShoppingCarts.Contracts;
using Shoeses.Services.ShoppingCarts.Contracts.Exeptions;

namespace Shoeses.Services.ShoppingCarts
{
  public  class ShoppingCartAppService: ShoppingCartService
    {
        private readonly ShoppingCartRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public ShoppingCartAppService(ShoppingCartRepository repository,UnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
            _repository = repository;
        }

        public async Task Add(AddShoppingCartDto dto)
        {
            var shoppingCart = new ShoppingCart
            {
                UserId = dto.UserId
            };

            _repository.Add(shoppingCart);
            await _unitOfWork.Complete();
        }


        public async Task Update(int id, UpdateShoppingCartDto dto)
        {
            var shoppingCart = _repository.Find(id);
            if (shoppingCart == null)
                throw new ShoppingCartNotFoundToUpdateException();

            shoppingCart.UserId = dto.UserId;

            _repository.Update(shoppingCart);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var shoppingCart = _repository.Find(id);
            if (shoppingCart == null)
                throw new ShoppingCartNotFoundToDeleteException();

            _repository.Delete(shoppingCart);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetShoppingCartDto>> GetAll()
        {
            var shoppingCarts = await _repository.GetAll();
            var dtos = shoppingCarts.Select(sc => new GetShoppingCartDto
            {
                Id = sc.Id,
                UserId = sc.UserId,
                ShoppingCartItems = sc.ShoppingCartItems.Select(sci => new GetShoppingCartItemDto
                {
                    Id = sci.Id,
                    Quantity = sci.Quantity,
                    ProductId = sci.ProductId,
                    Product = new GetProductDto
                    {
                       
                        Name = sci.Product.Name,
                        Description = sci.Product.Description,
                        Price = sci.Product.Price,
                        Count = sci.Product.Count,
                        CategoryId = sci.Product.CategoryId,
                        PromotionId = sci.Product.PromotionId,
                        Category = new GetCategoryDto
                        {
                            Id = sci.Product.Category.Id,
                            Name = sci.Product.Category.Name
                        },
                        Promotion = new GetPromotionDto
                        {
                            Id = sci.Product.Promotion.Id,
                            Code = sci.Product.Promotion.Code,
                            Description = sci.Product.Promotion.Description,
                            DiscountAmount = sci.Product.Promotion.DiscountAmount,
                            StartDate = sci.Product.Promotion.StartDate,
                            EndDate = sci.Product.Promotion.EndDate
                        },
                        ProductImages = sci.Product.ProductImages.Select(pi => new GetProductImageDto
                        {
                            Id = pi.Id,
                            ImageUrl = pi.ImageUrl
                        }).ToList(),
                        Reviews = sci.Product.Reviews.Select(r => new GetReviewsDto
                        {
                            Id = r.Id,
                            Rating = r.Rating,
                            ProductId = r.ProductId
                        }).ToList()
                    }
                }).ToList()
            }).ToList();

            return dtos;
        }

        public async Task<GetShoppingCartDto> GetById(int id)
        {
            var shoppingCart = _repository.Find(id);
            if (shoppingCart == null)
                throw new ShoppingCartNotFoundGetByIdException();

            var dto = new GetShoppingCartDto
            {
                Id = shoppingCart.Id,
                UserId = shoppingCart.UserId,
                ShoppingCartItems = shoppingCart.ShoppingCartItems.Select(sci => new GetShoppingCartItemDto
                {
                    Id = sci.Id,
                    Quantity = sci.Quantity,
                    ProductId = sci.ProductId,
                    Product = new GetProductDto
                    {
                        
                        Name = sci.Product.Name,
                        Description = sci.Product.Description,
                        Price = sci.Product.Price,
                        Count = sci.Product.Count,
                        CategoryId = sci.Product.CategoryId,
                        PromotionId = sci.Product.PromotionId,
                        Category = new GetCategoryDto
                        {
                            Id = sci.Product.Category.Id,
                            Name = sci.Product.Category.Name
                        },
                        Promotion = new GetPromotionDto
                        {
                            Id = sci.Product.Promotion.Id,
                            Code = sci.Product.Promotion.Code,
                            Description = sci.Product.Promotion.Description,
                            DiscountAmount = sci.Product.Promotion.DiscountAmount,
                            StartDate = sci.Product.Promotion.StartDate,
                            EndDate = sci.Product.Promotion.EndDate
                        },
                        ProductImages = sci.Product.ProductImages.Select(pi => new GetProductImageDto
                        {
                            Id = pi.Id,
                            ImageUrl = pi.ImageUrl
                        }).ToList(),
                        Reviews = sci.Product.Reviews.Select(r => new GetReviewsDto
                        {
                            Id = r.Id,
                            Rating = r.Rating,
                            ProductId = r.ProductId
                        }).ToList()
                    }
                }).ToList()
            };

            return dto;
        }
    }
}
