using AutoMapper;
using Restaurant.Services.ProductApi.Models;
using Restaurant.Services.ProductApi.Models.Dto;

namespace Restaurant.Services.ProductApi
{
    public static class MappingConfig    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
           {
               config.CreateMap<ProductDto, Product>();
               config.CreateMap<Product, ProductDto>();
           });
            return mappingConfig;
        }
    }
}
