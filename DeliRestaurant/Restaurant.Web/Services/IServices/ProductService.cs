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
        public async Task<T> CreateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = product,
                Url = Constants.ProductApiBase,
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.DELETE,              
                Url = Constants.ProductApiBase + "/"+ productId,
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ProductApiBase + "/" + productId,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ProductApiBase ,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.PUT,
                Data = product,
                Url = Constants.ProductApiBase,
                AccessToken = ""
            });
        }
    }
}
