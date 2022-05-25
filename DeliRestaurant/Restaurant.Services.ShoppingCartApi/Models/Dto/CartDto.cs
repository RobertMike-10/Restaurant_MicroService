namespace Restaurant.Services.ShoppingCartApi.Models.Dto
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailDto> CarDetails { get; set; }


    }
}
