using Shoeses.Entitis.Users;
using Shoeses.Services.Users.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Categoryes;
using Shoeses.Services.Categoryes.Contracts.Dtos;

namespace Shoeses.Services.Categoryes.Contracts
{
  public interface CatecoryesRepository
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Category? Find(int id);
        Task<List<GetCategoryDto>> GetAll();
        bool IsExistCatecoery(int id);
        Task<bool> IsCategoryNameExist(string name); // اضافه کردن متد جدی

    }
}
