using Shoeses.Entitis.Reviews;
using Shoeses.Services.Reviews.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Reviews.Contracts
{
    public interface ReviewRepository
    {
        void Add(Review review);
        void Update(Review review);
        void Delete(Review review);
        Review Find(int id);
        Task<List<GetReviewsDto>> GetAll();
    }
}
