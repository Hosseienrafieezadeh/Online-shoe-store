using Shoeses.Services.Promotions.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Promotions.Contracts
{
   public interface PromotionService
    {
        Task Add(AddPromotionDto dto);
        Task Update(int id, UpdatePromotionDto dto);
        Task Delete(int id);
        Task<List<GetPromotionDto>> GetAll();
        Task<GetPromotionDto> GetById(int id);
    }
}
