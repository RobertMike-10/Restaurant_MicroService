namespace Restaurant.Web.Models
{
    public class CardDto
    {
        public long? CreditCardNumber { get; set; }
        public int? CVV { get; set; }
        public string? ExpiryMonthYear { get; set; }
    }
}
