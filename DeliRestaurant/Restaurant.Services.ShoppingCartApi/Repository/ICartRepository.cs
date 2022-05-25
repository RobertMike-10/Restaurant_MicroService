using Restaurant.Services.ShoppingCartApi.Models.Dto;

namespace Restaurant.Services.ShoppingCartApi.Repository
{
    public interface ICartRepository
    {
       Task<CartDto> GetCartUserById(string userId);
       Task<CartDto> CreateUpdateCart(CartDto carDto);
       Task<bool> RemoveFromCart(int cartDetailId);

        Task<bool> ClearCart(string userId);


    }
}
