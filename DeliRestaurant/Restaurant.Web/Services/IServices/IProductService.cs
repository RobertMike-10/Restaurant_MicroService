
using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface IProductService: IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int productId);
        Task<T> CreateProductAsync<T>(ProductDto product);
        Task<T> UpdateProductAsync<T>(ProductDto product);
        Task<T> DeleteProductAsync<T>(int productId);
    }
}
