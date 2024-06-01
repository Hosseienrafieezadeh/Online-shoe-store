using Shoeses.Contracts.Interface;
using Shoeses.Entitis.Reviews;
using Shoeses.Services.Reviews.Contracts.Dtos;
using Shoeses.Services.Reviews.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Reviews.Contracts.Exeptions;

namespace Shoeses.Services.Reviews
{
    public class ReviewAppService:ReviewService
    {
        private readonly ReviewRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public ReviewAppService(ReviewRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddReviewDto dto)
        {
            var review = new Review
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                ReviewDate = dto.ReviewDate
            };

            _repository.Add(review);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateReviewDto dto)
        {
            var review = _repository.Find(id);
            if (review == null) throw new ReviewNotFoundExceptionToUpdate();

            review.UserId = dto.UserId;
            review.ProductId = dto.ProductId;
            review.Rating = dto.Rating;
            review.Comment = dto.Comment;
            review.ReviewDate = dto.ReviewDate;

            _repository.Update(review);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var review = _repository.Find(id);
            if (review == null) throw new ReviewNotFoundException();

            _repository.Delete(review);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetReviewsDto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
