using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory): base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto product, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = product,
                Url = Constants.ProductApiBase,
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.DELETE,              
                Url = Constants.ProductApiBase + "/"+ productId,
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ProductApiBase + "/" + productId,
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>( string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ProductApiBase ,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto product, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.PUT,
                Data = product,
                Url = Constants.ProductApiBase,
                AccessToken = token
            });
        }
    }
}
