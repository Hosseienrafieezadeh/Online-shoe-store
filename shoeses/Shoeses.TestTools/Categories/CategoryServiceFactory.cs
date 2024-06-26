using Shoeses.persistence.EF;
using Shoeses.persistence.EF.Categoryes;
using Shoeses.persistence.EF.Products;
using Shoeses.Services.Categoryes;
using Shoeses.Services.Categoryes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.TestTools.Categories
{
    public static class CategoryServiceFactory
    {
        public static CategoryService Create(EFDataContext context) 
        {
            return new CategoryAppServiec(new EFCategoryesRepository(context), new EFUnitOfWork(context), new EFProductRepository(context));
        }
    }
}
