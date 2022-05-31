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

        public async Task<T> AddToCartAsync<T>(CartDto cart, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = cart,
                Url = Constants.ShoppingCartApiBase + "/AddCart",
                AccessToken = token
            });
        }

        public async Task<T> ApplyCoupon<T>(CartDto cart, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = cart,
                Url = Constants.ShoppingCartApiBase + "/ApplyCoupon",
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

        public async Task<T> GetCartUserByIdAsync<T>(string userId, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ShoppingCartApiBase + "/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveCoupon<T>(string userId, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = userId,
                Url = Constants.ShoppingCartApiBase + "/RemoveCoupon",
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

        public async Task<T> UpdateToCartAsync<T>(CartDto cart, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = cart,
                Url = Constants.ShoppingCartApiBase + "/UpdateCart",
                AccessToken = token
            });
        }
    }
}
