using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Promotions.Contracts;

namespace Shoeses.persistence.EF.Promotions
{
    public class EFPromotionRepository:PromotionRepository
    {
        private readonly EFDataContext _context;

        public EFPromotionRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Promotion promotion)
        {
            _context.Promotions.Add(promotion);
        }

        public void Update(Promotion promotion)
        {
            _context.Promotions.Update(promotion);
        }

        public void Delete(Promotion promotion)
        {
            _context.Promotions.Remove(promotion);
        }

        public Promotion Find(int id)
        {
            return _context.Promotions
                .Include(p => p.ApplicableProducts)
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Promotion>> GetAll()
        {
            return await _context.Promotions
                .Include(p => p.ApplicableProducts)
                .ToListAsync();
        }
    }
}
