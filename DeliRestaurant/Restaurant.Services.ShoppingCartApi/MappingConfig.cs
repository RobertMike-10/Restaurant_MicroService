using AutoMapper;
using Restaurant.Services.ShoppingCartApi.Models;
using Restaurant.Services.ShoppingCartApi.Models.Dto;

namespace Restaurant.Services.ShoppingCartApi
{
    public static class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<CartHeaderDto, CartHeader>();
                config.CreateMap<CartHeader, CartHeaderDto>();
                config.CreateMap<CartDetailDto, CartDetail>();
                config.CreateMap<CartDetail, CartDetailDto>();
                config.CreateMap<CartDto, Cart>();
                config.CreateMap<Cart, CartDto>();

            });
            return mappingConfig;
        }
    }
}
