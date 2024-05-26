using Shoeses.Entitis.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.Categoryes
{
    public class Category
    {
        public int Id { get; set; }  // شناسه یکتا برای دسته‌بندی
        public string Name { get; set; }  // نام دسته‌بندی

        public List<Product> Products { get; set; } = new();  // لیستی از محصولات متعلق به این دسته‌بندی
    }

}
