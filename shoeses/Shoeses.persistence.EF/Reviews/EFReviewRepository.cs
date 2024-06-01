using Shoeses.Entitis.Reviews;
using Shoeses.Services.Reviews.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoeses.Services.Reviews.Contracts;

namespace Shoeses.persistence.EF.Reviews
{
    public class EFReviewRepository:ReviewRepository
    {
        private readonly EFDataContext _context;

        public EFReviewRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public Review Find(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public async Task<List<GetReviewsDto>> GetAll()
        {
            return await _context.Reviews.Select(review => new GetReviewsDto
            {
                Id = review.Id,
                UserId = review.UserId,
                ProductId = review.ProductId,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            }).ToListAsync();
        }
    }
}
