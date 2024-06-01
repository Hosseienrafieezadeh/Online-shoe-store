using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Reviews.Contracts.Dtos
{
    public class AddReviewDto
    {
        [Required]
        public string? UserId { get; set; }  // شناسه کاربری که این نقد و بررسی را نوشته است
        [Required]
        public int? ProductId { get; set; }  // شناسه محصول مورد بررسی
        [Required]
        public int? Rating { get; set; }  // امتیاز (مثلاً از 1 تا 5)
        [Required]
        public string? Comment { get; set; }  // متن نقد و بررسی
        [Required]
        public DateTime? ReviewDate { get; set; }  // تاریخ نوشتن نقد و بررسی
    }
}
