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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public CreditCard? Card { get; set; }


    }
}
