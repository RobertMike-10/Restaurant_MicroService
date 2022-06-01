namespace Restaurant.Services.ShoppingCartApi.Models.Dto
{
    public class CardDto
    {
        public long? CreditCardNumber { get; set; }
        public int? CVV { get; set; }
        public string? ExpiryMonthYear { get; set; }
    }
}
