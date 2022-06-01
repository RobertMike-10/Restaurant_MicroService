using Restaurant.Services.ShoppingCartApi.Models.Dto;

namespace Restaurant.Services.ShoppingCartApi.Messages
{
    public class CheckoutHeaderDto
    {
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
        public string? CouponCode { get; set; }
        public Decimal OrderTotal { get; set; }
        public Decimal DiscountTotal { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public string? PhoneNumber { get; set; }       
        public CardDto? Card { get; set; }
        public string? ExpiryMonthYear { get; set; }
        public int CartTotalItems { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}
 