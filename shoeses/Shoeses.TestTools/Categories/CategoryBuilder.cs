using Shoeses.Entitis.Categoryes;
using Shoeses.Entitis.ProductImages;
using Shoeses.Entitis.Products;
using Shoeses.Entitis.Reviews;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.Products.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shoeses.TestTools.Categories
{
    public class CategoryBuilder
    {
        private readonly Category _category;
        public CategoryBuilder()
        {
            var date = new DateTime(2015, 3, 10, 2, 15, 10);
            _category = new Category
            {
                Name = "Test Category",
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "Product Name",
                        Description = "Product Description",
                        Count = 1,
                        Price = 1000,
                        ProductImages = new List<ProductImage>
                        {
                            new ProductImage
                            {
                                ImageUrl = "stringUrl",
                            }
                        },
                        Reviews = new List<Review>
                        {
                            new Review
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

        public Category Build()
        {
            return _category;
        }
    }
}
