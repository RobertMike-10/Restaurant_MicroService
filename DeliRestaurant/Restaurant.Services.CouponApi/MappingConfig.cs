using AutoMapper;
using Restaurant.Services.CouponApi.Models;
using Restaurant.Services.CouponApi.Models.Dto;

namespace Restaurant.Services.CouponApi
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();            

            });
            return mappingConfig;
        }
    }
}
