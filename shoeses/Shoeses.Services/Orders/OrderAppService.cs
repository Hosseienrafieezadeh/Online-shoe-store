using Shoeses.Contracts.Interface;
using Shoeses.Entitis.OrderDetails;
using Shoeses.Entitis.Orders;
using Shoeses.Services.Orders.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Orders.Contracts;
using Shoeses.Services.Addresses.Contracts.Dtos;
using Shoeses.Services.OrderDetails.Contracts.Dtos;
using Shoeses.Services.Orders.Contracts.Exeptions;
using Shoeses.Services.Products.Contracts.Dtos;
using Shoeses.Services.ShoppingCarts.Contracts.Dtos;
using Shoeses.Services.Users.Contracts.Dtos;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Promotions.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;
using Shoeses.Entitis.Payments;

namespace Shoeses.Services.Orders
{
    public class OrderAppService:OrderService
    {
        private readonly OrderRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public OrderAppService(OrderRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddOrderDto dto)
        {
            var order = new Order
            {
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                OrderStatus = dto.OrderStatus,
                UserId = dto.UserId,
                ShippingAddressId = dto.ShippingAddressId,
                ShoppingCartId = dto.ShoppingCartId,
                OrderDetails = dto.OrderDetails.Select(d => new OrderDetail
                {
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    ProductId = d.ProductId
                }).ToList()
            };

            _repository.Add(order);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateOrderDto dto)
        {
            var order = _repository.Find(id);
            if (order == null)
                throw new OrderNotFoundToUpdateException();

            order.OrderDate = dto.OrderDate;
            order.TotalAmount = dto.TotalAmount;
            order.OrderStatus = dto.OrderStatus;
            order.UserId = dto.UserId;
            order.ShippingAddressId = dto.ShippingAddressId;
            order.ShoppingCartId = dto.ShoppingCartId;

            // Update OrderDetails
            foreach (var detail in order.OrderDetails.ToList())
            {
                _repository.RemoveOrderDetail(detail);
            }

            order.OrderDetails = dto.OrderDetails.Select(d => new OrderDetail
            {
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice,
                ProductId = d.ProductId
            }).ToList();

            _repository.Update(order);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var order = _repository.Find(id);
            if (order == null)
                throw new OrderNotFoundToDeleteException();

            _repository.Delete(order);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetOrderDto>> GetAll()
        {
            var orders = await _repository.GetAll();
            if (orders == null || !orders.Any())
                return new List<GetOrderDto>();

            return orders.Select(o => new GetOrderDto
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                OrderStatus = o.OrderStatus,
                UserId = o.UserId,
                User = new GetUserDto
                {
                    Id = o.User.Id,
                    Email = o.User.Email
                },
                ShippingAddressId = o.ShippingAddressId,
                ShippingAddress = new GetAdressDto
                {
                    Id = o.ShippingAddress.Id,
                    Street = o.ShippingAddress.Street,
                    City = o.ShippingAddress.City,
                    State = o.ShippingAddress.State,
                    PostalCode = o.ShippingAddress.PostalCode,
                    Country = o.ShippingAddress.Country
                },
                ShoppingCartId = o.ShoppingCartId,
                ShoppingCart = new GetShoppingCartDto
                {
                    Id = o.ShoppingCart.Id,
                    ShoppingCartItems = o.ShoppingCart.ShoppingCartItems.Select(sci => new GetShoppingCartItemDto
                    {
                        Id = sci.Id,
                        Quantity = sci.Quantity,
                        ProductId = sci.ProductId,
                        Product = new GetProductDto
                        {
                            Id = sci.Product.Id,
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
                                Rating = r.Rating
                            }).ToList()
                        }
                    }).ToList()
                },
                OrderDetails = o.OrderDetails.Select(od => new GetOrderDetailDto
                {
                    Id = od.Id,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                    ProductId = od.ProductId,
                    Product = new GetProductDto
                    {
                        Id = od.Product.Id,
                        Name = od.Product.Name,
                        Description = od.Product.Description,
                        Price = od.Product.Price,
                        Count = od.Product.Count,
                        CategoryId = od.Product.CategoryId,
                        PromotionId = od.Product.PromotionId,
                        Category = new GetCategoryDto
                        {
                            Id = od.Product.Category.Id,
                            Name = od.Product.Category.Name
                        },
                        Promotion = new GetPromotionDto
                        {
                            Id = od.Product.Promotion.Id,
                            Code = od.Product.Promotion.Code,
                            Description = od.Product.Promotion.Description,
                            DiscountAmount = od.Product.Promotion.DiscountAmount,
                            StartDate = od.Product.Promotion.StartDate,
                            EndDate = od.Product.Promotion.EndDate
                        },
                        ProductImages = od.Product.ProductImages.Select(pi => new GetProductImageDto
                        {
                            Id = pi.Id,
                            ImageUrl = pi.ImageUrl
                        }).ToList(),

                    }
                }).ToList()
            }).ToList();
        }



        public async Task<GetOrderDto> GetById(int id)
        {
            var order = _repository.Find(id);
            if (order == null)
                throw new orderNotFoundTOGetByIdException();

            return new GetOrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                OrderStatus = order.OrderStatus,
                UserId = order.UserId,
                User = new GetUserDto()
                {
                    Id = order.User.Id,
                    Email = order.User.Email
                },
                ShippingAddressId = order.ShippingAddressId,
                ShippingAddress = new GetAdressDto()
                {
                    Id = order.ShippingAddress.Id,
                    Street = order.ShippingAddress.Street,
                    City = order.ShippingAddress.City,
                    State = order.ShippingAddress.State,
                    PostalCode = order.ShippingAddress.PostalCode,
                    Country = order.ShippingAddress.Country
                },
                ShoppingCartId = order.ShoppingCartId,
                ShoppingCart = new GetShoppingCartDto()
                {
                    Id = order.ShoppingCart.Id,
                    ShoppingCartItems = order.ShoppingCart.ShoppingCartItems.Select(sci => new GetShoppingCartItemDto()
                    {
                        Id = sci.Id,
                        Quantity = sci.Quantity,
                        ProductId = sci.ProductId,
                        Product = new GetProductDto()
                        {
                            Id = sci.Product.Id,
                            Name = sci.Product.Name
                        }
                    }).ToList()
                },
                OrderDetails = order.OrderDetails.Select(od => new GetOrderDetailDto
                {
                    Id = od.Id,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                    ProductId = od.ProductId,
                    Product = new GetProductDto()
                    {
                        Id = od.Product.Id,
                        Name = od.Product.Name
                    }
                }).ToList()
            };
        }
        public async Task AddPayment(int orderId, Payment payment)
        {
            var order = _repository.Find(orderId);
            if (order == null)
                throw new OrderNotFoundException();

            order.Payments.Add(payment);
            _repository.Update(order);
            await _unitOfWork.Complete();
        }

        public async Task<List<Payment>> GetPaymentsByOrderId(int orderId)
        {
            var order = _repository.Find(orderId);
            if (order == null)
                throw new OrderNotFoundException();

            return order.Payments;
        }
    }
}
