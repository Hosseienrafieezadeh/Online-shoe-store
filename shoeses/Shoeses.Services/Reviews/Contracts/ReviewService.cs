using Shoeses.Services.Reviews.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Reviews.Contracts
{
    public interface ReviewService
    {
        Task Add(AddReviewDto dto);
        Task Update(int id, UpdateReviewDto dto);
        Task Delete(int id);
        Task<List<GetReviewsDto>> GetAll();
    }
}
