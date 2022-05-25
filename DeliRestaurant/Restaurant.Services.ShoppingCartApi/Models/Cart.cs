namespace Restaurant.Services.ShoppingCartApi.Models
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetail> CarDetails { get; set; }


    }
}
