using Shoeses.Services.Categoryes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Categoryes;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.persistence.EF.Categoryes
{
    public class EFCategoryesRepository: CatecoryesRepository
    {
        private readonly EFDataContext _context;

        public EFCategoryesRepository(EFDataContext context)
        {
            _context = context;
        }
        public void Add(Category category)
        {
           _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public Category? Find(int id)
        {
          return  _context.Categories.FirstOrDefault(_ => _.Id == id);
        }

        public async Task<List<GetCategoryDto>> GetAll()
        {
            IQueryable<Category> query = _context.Categories.Include(_=>_.Products);
            List<GetCategoryDto> categories = await query.Select(category => new GetCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => new GetProductDto()
                {
                    Id = p.Id,
                    Name = p.Name

                }).ToList()
            }).ToListAsync();
            return categories;

        }

        public bool IsExistCatecoery(int id)
        {
           return _context.Categories.Any(_ => _.Id == id);
        }

        public async  Task<bool> IsCategoryNameExist(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }
    }
}

