using Restaurant.Services.ShoppingCartApi.Models.Dto;

namespace Restaurant.Services.ShoppingCartApi.Repository
{
    public class CartRepository : ICartRepository
    {
        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> CreateUpdateCart(CartDto carDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> GetCartUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(int cartDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
