using Restaurant.Services.CouponApi.Models.Dto;

namespace Restaurant.Services.CouponApi.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);

    }
}
