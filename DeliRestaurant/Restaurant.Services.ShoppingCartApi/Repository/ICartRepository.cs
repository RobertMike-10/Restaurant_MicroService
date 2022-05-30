using Restaurant.Services.ShoppingCartApi.Models.Dto;

namespace Restaurant.Services.ShoppingCartApi.Repository
{
    public interface ICartRepository
    {
       Task<CartDto> GetCartUserById(string userId);
       Task<CartDto?> CreateUpdateCart(CartDto cartDto);
       Task<bool> RemoveFromCart(int cartDetailId);
       Task<bool> ClearCart(string userId);
       Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
    }
}
