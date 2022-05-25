using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface ICartService
    {
        Task<T> GetGetCartUserByIdAsync<T>(string userId, string? token = null);
        Task<T> AddToCartAsync<T>(CartDto car, string? token = null);
        Task<T> UpdateToCartAsync<T>(CartDto car, string? token = null);
        Task<T> RemoveFromCartAsync<T>(int cartId, string? token = null);
        Task<T> ClearCart<T>(string userId, string? token = null);
    }
}
