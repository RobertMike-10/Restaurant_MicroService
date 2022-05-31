namespace Restaurant.Web.Models
{
    public class CreditCard
    {
        public long? CreditCardNumber { get; set; }
        public int? CVV { get; set; }
        public string? ExpiryMonthYear { get; set; }
    }
}
