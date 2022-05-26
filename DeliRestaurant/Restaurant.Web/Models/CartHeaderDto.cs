using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models
{
    public class CartHeaderDto
    {
        public int CartHeaderId { get; set; }

        [Required]
        public string UserId { get; set; }
        public string? CouponCode { get; set; }
        public Decimal OrderTotal { get; set; }
        public Decimal DiscountTotal { get; set; }

    }
}
