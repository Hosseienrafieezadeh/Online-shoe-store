using Shoeses.Services.Users.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.Services.Categoryes.Contracts
{
   public interface CategoryService
    {
        Task Add(AddCategoryDto dto);
        Task Update(int Id, UpdateCategoriesDto dto);
        Task Delete(int id);
        Task<List<GetCategoryDto>> GetAll();
    }
}
