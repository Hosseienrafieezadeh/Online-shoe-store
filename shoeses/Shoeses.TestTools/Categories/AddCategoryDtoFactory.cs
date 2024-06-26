using Shoeses.Entitis.Categoryes;
using Shoeses.Entitis.Products;
using Shoeses.Entitis.Promotions;
using Shoeses.Entitis.Reviews;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Products.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.TestTools.Categories
{
    public static class AddCategoryDtoFactory
    {
        
        
        public static AddCategoryDto Create()
        {
            var date = new DateTime(2015, 3, 10, 2, 15, 10);
            var promotion = new Promotion
            {
                Id = 4,
                Code = "PROMO2024",
                Description = "Special Discount for 2024",
                DiscountAmount = 100,
                StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 12, 31),
                ApplicableProducts = new List<Product>()
                
            };
            var catgory = new Category
            {
                Id = 4,
                Name = "2",

            };
         
            return new AddCategoryDto()
            {
                Name = "Category",
                Products = new List<AddProductDto>
                {
                    new AddProductDto
                    {
                        Name = "Product Name",
                        Description = "Product Description",
                        Count = 1,
                        Price = 1000,
                     CategoryId = catgory.Id,
                        PromotionId =promotion.Id,
                      // Ensure this ID exists in the Promotions table
                        ProductImages = new List<AddProductImageDto>
                        {
                            new AddProductImageDto
                            {
                                ImageUrl = "stringUrl",
                            }
                        },
                        Reviews = new List<AddReviewDto>
                        {
                            new AddReviewDto
                            {
                                UserId = "stringId",
                                Comment = "comment",
                                Rating = 5,
                                ReviewDate = date
                            }
                        }
                    }
                }
            };

        }
    }
}

