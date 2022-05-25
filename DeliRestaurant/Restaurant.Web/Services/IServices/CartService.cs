using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public class CartService: BaseService, ICartService
    {

        private readonly IHttpClientFactory _clientFactory;
        public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> AddToCartAsync<T>(CartDto car, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = car,
                Url = Constants.ShoppingCartApiBase + "/AddCart",
                AccessToken = token
            });
        }

        public async Task<T> ClearCart<T>(string userId, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.DELETE,
                Url = Constants.ShoppingCartApiBase + "/ClearCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> GetGetCartUserByIdAsync<T>(string userId, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ShoppingCartApiBase + "/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = cartId,
                Url = Constants.ShoppingCartApiBase + "/RemoveCart",
                AccessToken = token
            });
        }

        public async Task<T> UpdateToCartAsync<T>(CartDto car, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = car,
                Url = Constants.ShoppingCartApiBase + "/UpdateCart",
                AccessToken = token
            });
        }
    }
}
