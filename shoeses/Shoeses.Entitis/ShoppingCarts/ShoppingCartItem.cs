using Shoeses.Entitis.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Entitis.ShoppingCarts
{
    /// <summary>
    /// مدیریت اقلامی که کاربران قصد خرید آنها را دارند.
    /// </summary>
    public class ShoppingCartItem
    {
        public int Id { get; set; }  // شناسه یکتا برای اقلام سبد خرید
        public int Quantity { get; set; }  // تعداد محصول در سبد خرید
        public int ShoppingCartId { get; set; }  // شناسه سبد خرید مرتبط
        public ShoppingCart ShoppingCart { get; set; }  // شیء سبد خرید مرتبط
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
