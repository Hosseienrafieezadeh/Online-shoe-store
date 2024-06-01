using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Reviews.Contracts.Dtos
{
    public class GetReviewsDto
    {
        public int Id { get; set; }  // شناسه یکتا برای نقد و بررسی
        public string UserId { get; set; }  // شناسه کاربری که این نقد و بررسی را نوشته است
        public int ProductId { get; set; }  // شناسه محصول مورد بررسی
        public int Rating { get; set; }  // امتیاز (مثلاً از 1 تا 5)
        public string Comment { get; set; }  // متن نقد و بررسی
        public DateTime ReviewDate { get; set; }  // تاریخ نوشتن نقد و بررسی
    }
}
