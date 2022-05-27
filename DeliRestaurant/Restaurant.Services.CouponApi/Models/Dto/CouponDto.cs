using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.CouponApi.Models.Dto
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
