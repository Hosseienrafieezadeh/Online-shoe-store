using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Contracts.Interface;
using Shoeses.Entitis.Categoryes;
using Shoeses.Entitis.Products;
using Shoeses.Services.Categoryes.Contracts;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Categoryes.Contracts.Exeptions;
using Shoeses.Services.Products.Contracts;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.Services.Categoryes
{
        public class CategoryAppServiec : CategoryService
        {
            private readonly CatecoryesRepository _repository;
            private readonly UnitOfWork _unitOfWork;
            private readonly ProductRepository _productRepository;

            public CategoryAppServiec(CatecoryesRepository repository, UnitOfWork unitOfWork, ProductRepository productRepository)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
                _productRepository = productRepository;
            }
            public async Task Add(AddCategoryDto dto)
            {
                if (await _repository.IsCategoryNameExist(dto.Name))
                {
                    throw new CategoryNameAlreadyExistException(); // استثناء خاص برای نام تکراری
                }
                var category = new Category
                {
                    Name = dto.Name,
                };
                _repository.Add(category);
                await _unitOfWork.Complete();
                category.Products = dto.Products.Select(_ => new Product()
                {
                    Name = _.Name,
                    Description = _.Description,
                    Price = _.Price,
                    Count = _.Count,
                    CategoryId = category.Id,
                    PromotionId = _.PromotionId,
                }).ToList();

                _repository.Update(category);
                await _unitOfWork.Complete();
            }

            public async Task Update(int Id, UpdateCategoriesDto dto)
            {
                var category = _repository.Find(Id);
                if (category == null)
                {
                    throw new CategoryNotFoundExceptionToUpdate();
                }

                category.Name = dto.Name;


                _repository.Update(category);
                await _unitOfWork.Complete();
            }

            public async Task Delete(int id)
            {
                var category = _repository.Find(id);
                if (category == null)
                {
                    throw new CategoryNotFoundException();
                }

                foreach (var product in category.Products)
                {
                    _productRepository.Delete(product);
                }

                _repository.Delete(category);
                await _unitOfWork.Complete();
            }

            public async Task<List<GetCategoryDto>> GetAll()
            {
                return await _repository.GetAll();
            }
        }
}
