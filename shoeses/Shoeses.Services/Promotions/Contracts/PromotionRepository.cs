using Shoeses.Entitis.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Promotions.Contracts
{
    public interface PromotionRepository
    {
        void Add(Promotion promotion);
        void Update(Promotion promotion);
        void Delete(Promotion promotion);
        Promotion Find(int id);
        Task<List<Promotion>> GetAll();
    }
}
