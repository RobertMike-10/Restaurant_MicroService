using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CouponService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetCoupon<T>(string CouponCode, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.CouponApiBase + "GetCoupon/" + CouponCode,
                AccessToken = token
            });
        }
    }
}
