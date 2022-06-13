using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface ICartService
    {
        Task<T> GetCartUserByIdAsync<T>(string userId, string? token = null);
        Task<T> AddToCartAsync<T>(CartDto cart, string? token = null);
        Task<T> UpdateToCartAsync<T>(CartDto cart, string? token = null);
        Task<T> RemoveFromCartAsync<T>(int cartId, string? token = null);
        Task<T> ClearCart<T>(string userId, string? token = null);
        Task<T> ApplyCoupon<T>(CartDto cart, string? token = null);
        Task<T> RemoveCoupon<T>(string userId, string? token = null);
        Task<T> Checkout<T>(CartHeaderDto cartHeader, string? token = null);
    }
}
