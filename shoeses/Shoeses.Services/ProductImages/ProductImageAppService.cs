using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Contracts.Interface;
using Shoeses.Entitis.ProductImages;
using Shoeses.Services.Categoryes.Contracts.Exeptions;
using Shoeses.Services.ProductImages.Contracts;
using Shoeses.Services.ProductImages.Contracts.Dtos;
using Shoeses.Services.ProductImages.Contracts.Exeptions;

namespace Shoeses.Services.ProductImages
{
   public class ProductImageAppService:ProductImageService
    {
        private readonly ProductImageRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public ProductImageAppService(ProductImageRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddProductImageDto dto)
        {
            if (await _repository.IsExsitedProduct(dto.ProductId))
            {
                throw new ProductIDAlreadyExistException();
            }
            var productImage = new ProductImage
            {
                ImageUrl = dto.ImageUrl,
                ProductId = dto.ProductId
            };

            _repository.Add(productImage);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateProductImageDto dto)
        {
            var productImage = _repository.Find(id);
            if (productImage == null) throw new ProductImageNotFoundExceptionToUpdate();

            productImage.ImageUrl = dto.ImageUrl;
            productImage.ProductId = dto.ProductId;

            _repository.Update(productImage);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var productImage = _repository.Find(id);
            if (productImage == null) throw new ProductImageNotFoundException();

            _repository.Delete(productImage);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetProductImageDto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
